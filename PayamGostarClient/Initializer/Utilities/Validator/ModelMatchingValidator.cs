using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.Initializer.Utilities.Validator
{
    public class ModelMatchingValidator : IModelMatchingValidator
    {
        private readonly IMatchingValidator _modelChecker;

        public ModelMatchingValidator() : this(new MatchingValidator())
        {
        }

        public ModelMatchingValidator(IMatchingValidator modelChecker)
        {
            _modelChecker = modelChecker;
        }


        public void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj)
        {
            CheckFieldMatching(baseCRMModel.Code, existedCrmObj.Code, "BaseCrmObj:Code -> ");
            CheckFieldMatching(baseCRMModel.Type, (Gp_CrmObjectType)existedCrmObj.CrmOjectTypeIndex, "BaseCrmObj:Type -> ");
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
                CheckFieldMatching(pair.Item1.IsDoneStage, pair.Item2.IsDoneStage, "CheckingStage:IsDoneStage -> ");
            }

            var newStages = intentedStages
                .Except(detectedPair.Select(d => d.Item1))
                .ToList();

            return newStages;
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
                CheckFieldMatching(pair.Item1.UserKey, pair.Item2.UserKey, "BaseExtendedPropertyModel:UserKey -> ");
                CheckFieldMatching(pair.Item1.Type, (Gp_ExtendedPropertyType)pair.Item2.PropertyDisplayTypeIndex, "BaseExtendedPropertyModel:Type -> ");
            }

            return intentedProperties.Except(detectedPair.Select(d => d.Item1));
        }


        private void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            _modelChecker.CheckFieldMatching(first, second, errorMessage);
        }


    }
}
