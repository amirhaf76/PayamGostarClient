using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.Comparers;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Utilities.CreationStrategies
{
    internal class StageCreationStrategy : IStageCreationStrategy
    {
        private readonly IPayamGostarCrmObjectTypeStageApiClient _stageApiClient;


        internal StageCreationStrategy(IPayamGostarCrmObjectTypeStageApiClient stageApiClient)
        {
            _stageApiClient = stageApiClient;
        }

        public async Task CreateStagesAsync(Guid id, List<Stage> stages)
        {
            if (!stages.Any())
            {
                return;
            }

            var aFinalStage = stages.FirstOrDefault(s => s.IsDoneStage == true);

            if (aFinalStage == null)
            {
                throw new NotFoundAtleastAFinalStageException($"In creation of crm object type, final stage is mandatory!");
            }

            stages.Sort(StagePriorityComparer.GetInstance());

            var index = 1;

            foreach (var stage in stages)
            {
                stage.Index = index++;

                stage.CrmObjectTypeId = id;

                await CreateStageAsync(stage);
            }
        }

        public async Task UpdateStagesAsync(Guid id, List<Stage> newStages, IEnumerable<Stage> existedStages)
        {
            if (!newStages.Any())
            {
                return;
            }

            existedStages = existedStages.Where(s => !s.IsDeleted);

            if (
                !existedStages.Where(s => s.IsDoneStage == true).Any() &&
                !newStages.Where(s => s.IsDoneStage == true).Any())
            {
                throw new NotFoundAtleastAFinalStageException($"Current crm object type with '{id}' id does not have any isDoneStage. The entered model must have a isDone stage.");
            }

            newStages.Sort(StagePriorityComparer.GetInstance());

            var startIndex = existedStages.Max(s => s.Index) + 1;

            foreach (var stage in newStages)
            {
                stage.Index = startIndex++;

                stage.CrmObjectTypeId = id;

                await CreateStageAsync(stage);
            }
        }

        private async Task CreateStageAsync(Stage stage)
        {
            var stageDto = stage.CreateStageCreationRequest();

            var stageCreationResult = await _stageApiClient.CreateAsync(stageDto);

            stage.Id = stageCreationResult.Result.StageId;
        }

    }
}
