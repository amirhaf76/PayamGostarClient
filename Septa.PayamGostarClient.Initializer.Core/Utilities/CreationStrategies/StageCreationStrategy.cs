using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Comparers;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.CreationStrategies
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

            index = await CreateStagesAndGetNextIndex(id, stages, index);
        }


        public async Task UpdateStagesAsync(Guid id, List<Stage> newStages, IEnumerable<StageGetResultDto> existedStages)
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

            var startIndex = existedStages.Any() ? existedStages.Max(s => s.Index) + 1 : 1;

            await CreateStagesAndGetNextIndex(id, newStages, startIndex);
        }


        private async Task CreateStageAsync(Stage stage)
        {
            var stageDto = stage.CreateStageCreationRequest();

            var stageCreationResult = await _stageApiClient.CreateAsync(stageDto);

            stage.Id = stageCreationResult.StageId;
        }

        private async Task<int> CreateStagesAndGetNextIndex(Guid id, List<Stage> stages, int index)
        {
            foreach (var stage in stages)
            {
                stage.Index = index++;

                stage.CrmObjectTypeId = id;

                await CreateStageAsync(stage);
            }

            return index;
        }

    }
}
