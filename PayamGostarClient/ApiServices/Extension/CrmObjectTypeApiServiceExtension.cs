using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeApiServiceExtension
    {
        private const string DEFAULT_LANGUAGE_CULTURE = "Fa";

        public static CrmObjectTypeSearchRequestVM ConvertToCrmObjectTypeSearchRequestVM(this BaseCrmModelDto crmModel, string languageCulture = DEFAULT_LANGUAGE_CULTURE, int pageSiz = 10, int pageNumber = 1)
        {
            return new CrmObjectTypeSearchRequestVM
            {
                Code = crmModel.Code,
                CrmObjectTypeIndex = (int?)crmModel.Type,
                PageNumber = pageNumber,
                PageSize = pageSiz,
                Name = crmModel.Name
                    .Where(x => x.LanguageCulture == languageCulture)
                    .FirstOrDefault()
                    .Value,
            };
        }
        public static CrmObjectTypeGetResultDto ConvertToCrmObjectTypeGetResultDto(this CrmObjectTypeGetResultVM viewModel)
        {
            var groupDictionary = new Dictionary<int, CrmObjectPropertyGroupGetResultDto>();

            foreach (var group in viewModel.Groups)
            {
                groupDictionary.Add(group.Id, new CrmObjectPropertyGroupGetResultDto
                {
                    CrmObjectTypeId = group.CrmObjectTypeId,
                    Name = group.Name,
                    NameResourceKey = group.NameResourceKey,
                    CountOfColumns = group.CountOfColumns,
                    ExpandForView = group.ExpandForView,
                });
            }

            var properties = viewModel.Properties.Select(property =>
            {
                const int INVALID_GROUP_ID = -1;

                groupDictionary.TryGetValue(
                    property.PropertyGroupId ?? INVALID_GROUP_ID,
                    out CrmObjectPropertyGroupGetResultDto propertyGroup);

                return new PropertyDefinitionGetResultDto
                {
                    UserKey = property.UserKey,
                    Name = property.Name,
                    NameResourceKey = property.NameResourceKey,
                    Tooltip = property.Tooltip,
                    TooltipResourceKey = property.TooltipResourceKey,
                    CrmObjectTypeId = property.CrmObjectTypeId,
                    Group = propertyGroup,
                };
            });

            return new CrmObjectTypeGetResultDto
            {
                Code = viewModel.Code,
                Name = viewModel.Name,
                CrmOjectTypeIndex = viewModel.CrmOjectTypeIndex,
                Description = viewModel.Description,
                Properties = properties,
                Groups = groupDictionary.Values.AsEnumerable(),
                Stages = viewModel.Stages.Select(stage => new CrmObjectTypeStageGetResultDto
                {
                    CrmObjectTypeId = stage.CrmObjectTypeId,
                    Name = stage.Name,
                    NameResourceKey = stage.NameResourceKey,
                    Key = stage.Key,
                    IsDoneStage = stage.IsDoneStage,
                    IsActive = stage.IsActive,
                }),
            };
        }

    }
}
