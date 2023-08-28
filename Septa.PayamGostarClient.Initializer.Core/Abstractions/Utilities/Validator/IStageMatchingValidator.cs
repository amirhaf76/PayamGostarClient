using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    internal interface IStageMatchingValidator
    {
        List<Stage> CheckMatchingAndGetNewStages(IEnumerable<Stage> intentedStages, IEnumerable<StageGetResultDto> existedStages);
    }
}