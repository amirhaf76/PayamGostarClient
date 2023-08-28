using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class ExtendedPropertyMatchingValidator : IExtendedPropertyMatchingValidator
    {
        private readonly IMatchingValidator _modelChecker;

        internal ExtendedPropertyMatchingValidator() : this(new MatchingValidator())
        {
        }

        internal ExtendedPropertyMatchingValidator(IMatchingValidator modelChecker)
        {
            _modelChecker = modelChecker;
        }


        public IEnumerable<BaseExtendedPropertyModel> CheckMatchingAndGetNewExtendedProperties(
           IEnumerable<BaseExtendedPropertyModel> intentedProperties,
           IEnumerable<ExtendedPropertyGetResultDto> existedProperties)
        {
            var detectedPair = intentedProperties.Join(
                existedProperties,
                intendedProperty => intendedProperty.UserKey,
                currentProperty => currentProperty.UserKey,
                (intendedProperty, currentProperty) => Tuple.Create(intendedProperty, currentProperty)
                );

            foreach (var pair in detectedPair)
            {
                _modelChecker.CheckFieldMatching(pair.Item1.UserKey, pair.Item2.UserKey, "BaseExtendedPropertyModel:UserKey -> ");
                _modelChecker.CheckFieldMatching(pair.Item1.Type, (Gp_ExtendedPropertyType)pair.Item2.PropertyDisplayTypeIndex, "BaseExtendedPropertyModel:Type -> ");
            }

            return intentedProperties.Except(detectedPair.Select(d => d.Item1));
        }
    }
}
