using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.Initializer.Comparers;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Extensions;
using PayamGostarClient.Initializer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.CreationStrategies
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

        public async Task UpdateStagesAsync(Guid id, List<Stage> stages, int startIndex)
        {
            if (!stages.Any())
            {
                return;
            }

            stages.Sort(StagePriorityComparer.GetInstance());

            foreach (var stage in stages)
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
