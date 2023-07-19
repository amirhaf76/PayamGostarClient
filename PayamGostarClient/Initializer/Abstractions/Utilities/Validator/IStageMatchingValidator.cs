using PayamGostarClient.Initializer.CrmModels;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Validator
{
    internal interface IStageMatchingValidator
    {
        List<Stage> CheckMatchingAndGetNewStages(IEnumerable<Stage> intentedStages, IEnumerable<Stage> existedStages);
    }
}