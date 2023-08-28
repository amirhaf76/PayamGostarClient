using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class StageMatchingValidator : IStageMatchingValidator
    {
        private readonly IMatchingValidator _modelChecker;

        internal StageMatchingValidator() : this(new MatchingValidator())
        {
        }

        internal StageMatchingValidator(IMatchingValidator modelChecker)
        {
            _modelChecker = modelChecker;
        }


        public List<Stage> CheckMatchingAndGetNewStages(IEnumerable<Stage> intentedStages, IEnumerable<Stage> existedStages)
        {
            existedStages = existedStages.Where(s => !s.IsDeleted);

            var detectedPair = intentedStages.Join(
                            existedStages,
                            intendedStage => intendedStage.Key,
                            currentStage => currentStage.Key,
                            (intendedStage, currentStage) => Tuple.Create(intendedStage, currentStage)
                            );

            foreach (var pair in detectedPair)
            {
                _modelChecker.CheckFieldMatching(pair.Item1.Key, pair.Item2.Key, "CheckingStage:IsDoneStage -> ");
            }

            var newStages = intentedStages
                .Except(detectedPair.Select(d => d.Item1))
                .ToList();

            return newStages;
        }
    }
}
