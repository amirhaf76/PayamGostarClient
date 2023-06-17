using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected T IntendedCrmObject { get; }

        protected IPayamGostarClientServiceFactory ServiceFactory { get; }

        protected ICrmObjectTypeService CrmObjectTypeService { get; }
        protected IExtendedPropertyService ExtendedPropertyService { get; }
        protected IPropertyGroupService PropertyGroupService { get; }
        protected ICrmObjectTypeStageService CrmObjectTypeStageService { get; }


        protected BaseInitService(T intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory)
        {
            IntendedCrmObject = intendedCrmObject;

            ServiceFactory = serviceFactory;

            CrmObjectTypeService = ServiceFactory.CreateCrmObjectTypeService();
            ExtendedPropertyService = ServiceFactory.CreateExtendedPropertyService();
            PropertyGroupService = ServiceFactory.CreatePropertyGroupService();
            CrmObjectTypeStageService = ServiceFactory.CreateCrmObjectTypeStageService();
        }

        public async Task InitAsync()
        {
            ValidateInitialValidationModel();

            var searchedCrmObject = await SearchCrmObjectAsync();

            if (searchedCrmObject == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync();
            }
            else
            {
                await CheckCrmObjectTypeBelongs(searchedCrmObject.Id);
            }
        }

        private void ValidateInitialValidationModel()
        {
            if (string.IsNullOrEmpty(IntendedCrmObject.Code))
            {
                throw new NullCrmCodeException();
            }

            if (!IntendedCrmObject.Properties.All(p => !string.IsNullOrEmpty(p.UserKey)))
            {
                throw new NullPropertyUserKeyExcpetion();
            }

            var propertyKeyGroups = IntendedCrmObject.Properties.GroupBy(p => p.UserKey);

            foreach (var propertyKeyGroup in propertyKeyGroups)
            {
                if (propertyKeyGroup.Count() > 1)
                {
                    throw new NonUniqeUserKeyException($"There is more than one property with \"{propertyKeyGroup.Key}\".");
                }
            }


        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            var newCrmObjectId = await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs(newCrmObjectId);
        }

        private async Task CheckCrmObjectTypeBelongs(Guid id)
        {
            var currentCrmObject = await GetCrmObjectTypeAsync(id);

            CheckBaseCrmObjectMatching(currentCrmObject);

            await CheckGroupPropetiesAsync(id, currentCrmObject.PropertyGroups);

            await CheckExtendedPropertiesAsync(id, currentCrmObject.Properties);

            await CheckStagesAsync(id, currentCrmObject.Stages);
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateGroupPropetiesAsync(id);

            await CreateExtendedPropertiesAsync(id);

            await CreateStagesAsync(id);
        }


        private async Task CheckStagesAsync(Guid id, IEnumerable<Stage> currentStages)
        {
            var newStages = new List<Stage>();

            foreach (var stage in IntendedCrmObject.Stages)
            {
                var newStage = CheckStage(stage, currentStages);

                if (newStage != null)
                {
                    newStages.Add(newStage);
                }
            }

            await CreateStagesAsync(id, newStages);
        }

        private async Task CheckGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups)
        {
            var newGroups = new List<PropertyGroup>();

            foreach (var group in IntendedCrmObject.PropertyGroups)
            {
                var newGroup = CheckGroupPropetyAndUpdateIdIfExists(group, groups);

                if (newGroup != null)
                {
                    newGroups.Add(newGroup);
                }
            }

            await CreateGroupPropetiesAsync(id, newGroups);
        }

        private async Task CheckExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> currentExtendedProperties)
        {
            var newProperties = CheckExtendedProperties(currentExtendedProperties);

            await CreateExtendedPropertiesAsync(id, newProperties);
        }


        private async Task<SearchedCrmObjectModel> SearchCrmObjectAsync()
        {
            var request = ToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            var receivedCrmObjects = await CrmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            if (receivedCrmObject == null)
            {
                return null;
            }

            return receivedCrmObject.ToModel();
        }

        private static CrmObjectTypeSearchRequestDto ToCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
            };
        }


        private async Task<Guid> CreateCrmObjectAsync()
        {
            return await CreateTypeAsync();
        }

        private async Task CreateStagesAsync(Guid id)
        {
            await CreateStagesAsync(id, IntendedCrmObject.Stages);
        }

        private async Task CreateStagesAsync(Guid id, List<Stage> stages)
        {
            if (!stages.Any())
            {
                 return;
            }

            var aFinalStage = stages.FirstOrDefault(s => s.IsDoneStage == true);

            if (aFinalStage == null)
            {
                throw new NotFoundAtleastAFinalStageException();
            }

            stages.Sort(StagePriorityComparer.GetInstance());

            foreach (var stage in stages)
            {
                await CreateStageAsync(id, stage);
            }
        }

        private async Task CreateStageAsync(Guid id, Stage stage)
        {
            var stageDto = stage.CreateStageCreationRequest(id);

            var stageCreationResult = await CrmObjectTypeStageService.CreateAsync(stageDto);

            stage.Id = stageCreationResult.Result.StageId;
        }

        private async Task CreateGroupPropetiesAsync(Guid id)
        {
            await CreateGroupPropetiesAsync(id, IntendedCrmObject.PropertyGroups);
        }

        private async Task CreateGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups)
        {
            foreach (var group in groups)
            {
                await CreateGroupPropetiesAsync(id, group);
            }
        }

        private async Task CreateGroupPropetiesAsync(Guid id, PropertyGroup group)
        {
            var groupDto = group.CreatePropertyGroupCreationRequest(id);

            var groupCreationResult = await PropertyGroupService.CreateAsync(groupDto);

            group.Id = groupCreationResult.Result.Id;
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id)
        {
            return await CreateExtendedPropertiesAsync(id, IntendedCrmObject.Properties);
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties)
        {
            var createdPropertiesId = new List<Guid>();

            foreach (var property in properties)
            {
                property.CrmObjectTypeId = id.ToString();

                var propertyDto = CreateExtendedPropertyDto(property);

                var response = await ExtendedPropertyService.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }


        protected abstract Task<Guid> CreateTypeAsync();

        protected abstract Task<T> GetCrmObjectTypeAsync(Guid id);

        protected abstract T CheckCrmObjectMatching(T currentCrmObj);

        private T CheckBaseCrmObjectMatching(T currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.Type, currentCrmObj.Type);
            CheckFieldMatching(IntendedCrmObject.Code, currentCrmObj.Code);
            CheckFieldMatching(IntendedCrmObject.Enabled, currentCrmObj.Enabled);
            CheckFieldMatching(IntendedCrmObject.PreviewTypeIndex, currentCrmObj.PreviewTypeIndex);

            if (!IntendedCrmObject.Name.CheckResourceValues(currentCrmObj.Name))
            {
                throw MisMatchException.Create(IntendedCrmObject.Name, currentCrmObj.Name);
            }

            if (!IntendedCrmObject.Description.CheckResourceValues(currentCrmObj.Description))
            {
                throw MisMatchException.Create(IntendedCrmObject.Description, currentCrmObj.Description);
            }

            return CheckCrmObjectMatching(currentCrmObj);
        }


        private PropertyGroup CheckGroupPropetyAndUpdateIdIfExists(PropertyGroup intendedGroup, IEnumerable<PropertyGroup> currentGroups)
        {
            var resourceValueComparer = ResourceValueEqualityComparer.GetInstance();

            foreach (var currentGroup in currentGroups)
            {
                if (intendedGroup.Name.Any(n => currentGroup.Name.Contains(n, resourceValueComparer)))
                {
                    if (!intendedGroup.Name.CheckResourceValues(currentGroup.Name))
                    {
                        throw new MisMatchException();
                    }

                    CheckFieldMatching(intendedGroup.Expanded, currentGroup.Expanded);
                    CheckFieldMatching(intendedGroup.CountOfColumns, currentGroup.CountOfColumns);

                    intendedGroup.Id = currentGroup.Id;

                    return null;
                }
            }

            return intendedGroup;
        }

        private Stage CheckStage(Stage intendedStage, IEnumerable<Stage> currentStages)
        {
            var resourceValueComparer = ResourceValueEqualityComparer.GetInstance();

            foreach (var currentStage in currentStages)
            {
                if (intendedStage.Name.Any(n => currentStage.Name.Contains(n, resourceValueComparer)))
                {
                    if (!intendedStage.Name.CheckResourceValues(currentStage.Name))
                    {
                        throw new MisMatchException();
                    }

                    CheckFieldMatching(intendedStage.Key, currentStage.Key);
                    CheckFieldMatching(intendedStage.Enabled, currentStage.Enabled);
                    CheckFieldMatching(intendedStage.IsDoneStage, currentStage.IsDoneStage);

                    return null;
                }
            }

            return intendedStage;
        }

        private IEnumerable<BaseExtendedPropertyModel> CheckExtendedProperties(IEnumerable<BaseExtendedPropertyModel> currentProperties)
        {
            var detectedPair = IntendedCrmObject.Properties.Join(
                currentProperties,
                intendedProperty => intendedProperty.UserKey,
                currentProperty => currentProperty.UserKey,
                (intendedProperty, currentProperty) => Tuple.Create(intendedProperty, currentProperty)
                );

            foreach (var pair in detectedPair)
            {
                CheckExtendedProperty(pair.Item1, pair.Item2);
            }

            return IntendedCrmObject.Properties.Except(detectedPair.Select(d => d.Item1));
        }


        private void CheckExtendedProperty(BaseExtendedPropertyModel item1, BaseExtendedPropertyModel item2)
        {
            switch (item1.Type)
            {
                case Gp_ExtendedPropertyType.Text:
                    new TextExtendedPropertyModelEqualityComparer()
                        .Checks((TextExtendedPropertyModel)item1, (TextExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Form:
                    new FormExtendedPropertyModelEqualityComparer()
                        .Checks((FormExtendedPropertyModel)item1, (FormExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.DropDownList:
                    new DropDownListExtendedPropertyModelEqualityComparer()
                        .Checks((DropDownListExtendedPropertyModel)item1, (DropDownListExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.User:
                    new UserExtendedPropertyModelEqualityComparer()
                        .Checks((UserExtendedPropertyModel)item1, (UserExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Number:
                    new NumberExtendedPropertyModelEqualityComparer()
                        .Checks((NumberExtendedPropertyModel)item1, (NumberExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Department:
                    new DepartmentExtendedPropertyModelEqualityComparer()
                        .Checks((DepartmentExtendedPropertyModel)item1, (DepartmentExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Position:
                    new PositionExtendedPropertyModelEqualityComparer()
                        .Checks((PositionExtendedPropertyModel)item1, (PositionExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Date:
                    new PersianDateExtendedPropertyModelEqualityComparer()
                        .Checks((PersianDateExtendedPropertyModel)item1, (PersianDateExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.Label:
                    new LabelExtendedPropertyModelEqualityComparer()
                        .Checks((LabelExtendedPropertyModel)item1, (LabelExtendedPropertyModel)item2);
                    break;

                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    new CrmObjectMultiValueExtendedPropertyModelEqualityComparer()
                        .Checks((CrmObjectMultiValueExtendedPropertyModel)item1, (CrmObjectMultiValueExtendedPropertyModel)item2);
                    break;

                default:
                    throw new NotFoundExtendedPropertyTypeException();
            }
        }

        private BaseExtendedPropertyCreationDto CreateExtendedPropertyDto(BaseExtendedPropertyModel propertyModel)
        {
            switch (propertyModel.Type)
            {
                case Gp_ExtendedPropertyType.Text:
                    return propertyModel.ToTextExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Form:
                    return propertyModel.ToFormExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.DropDownList:
                    return propertyModel.ToDropDownListExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.User:
                    return propertyModel.ToUserExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Number:
                    return propertyModel.ToNumberExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Department:
                    return propertyModel.ToDepartmentExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Position:
                    return propertyModel.ToPositionExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Date:
                    return propertyModel.ToPersianDateExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Label:
                    return propertyModel.ToLabelExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return propertyModel.ToCrmObjectMultiValueExtendedPropertyCreationDto();

                default:
                    throw new NotFoundExtendedPropertyTypeException();
            }
        }

        protected static void CheckFieldMatching<TField>(TField first, TField second)
        {
            ModelChecker.CheckFieldMatching(first, second);
        }

    }

    internal static class ModelChecker
    {
        internal static bool CheckResourceValues(this IEnumerable<ResourceValue> first, IEnumerable<ResourceValue> second)
        {
            return first
                .Join(
                    second,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .All(join => join.Item1 == join.Item2);
        }

        internal static void CheckFieldMatching<TField>(TField first, TField second)
        {
            if (typeof(TField) == typeof(string))
            {
                if (
                    (string.IsNullOrEmpty(first as string) && !string.IsNullOrEmpty(second as string)) ||
                    (!string.IsNullOrEmpty(first as string) && string.IsNullOrEmpty(second as string)))
                {
                    throw new MisMatchException($"{first} != {second}");
                }

                if (string.IsNullOrEmpty(first as string) && string.IsNullOrEmpty(second as string))
                {
                    return;
                }
            }

            if (first == null && second == null)
            {
                return;
            }

            if (!first.Equals(second))
            {
                throw new MisMatchException($"{first} != {second}");
            }
        }

    }
}
