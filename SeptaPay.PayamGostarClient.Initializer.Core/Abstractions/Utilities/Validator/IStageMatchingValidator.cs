using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    internal interface IStageMatchingValidator
    {
        List<Stage> CheckMatchingAndGetNewStages(IEnumerable<Stage> intentedStages, IEnumerable<Stage> existedStages);
    }
}