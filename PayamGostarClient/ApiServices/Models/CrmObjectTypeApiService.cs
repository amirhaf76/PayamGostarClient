using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class CrmObjectTypeApiService : ICrmObjectTypeApiService
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeApiClient;

        private readonly PayamGostarClientConfig _payamGostarClientConfig;

        public CrmObjectTypeApiService(PayamGostarClientConfig payamGostarClientConfig, ICrmObjectTypeApiClient crmObjectTypeApiClient)
        {
            _payamGostarClientConfig = payamGostarClientConfig;
            _crmObjectTypeApiClient = crmObjectTypeApiClient;
        }

        public async Task<IEnumerable<CrmObjectTypeGetResultDto>> SearchAsync(BaseCRMModel baseCRM)
        {
            var searchResult = await _crmObjectTypeApiClient.PostApiV2CrmobjecttypeSearchAsync(new CrmObjectTypeSearchRequestVM
            {
                Code = baseCRM.Code,
                CrmObjectTypeIndex = (int?)baseCRM.Type,
                PageNumber = 1,
                PageSize = 10,
                Name = baseCRM.Name
                    .Where(x => x.LanguageCulture == _payamGostarClientConfig.LanguageCulture)
                    .FirstOrDefault()
                    .Value,
            });

            return searchResult.Result.Select(res => new CrmObjectTypeGetResultDto
            {
                Code = res.Code,
                Name = res.Name,
                CrmOjectTypeIndex = res.CrmOjectTypeIndex,
                Description = res.Description,
                Properties = res.Properties.Select(property => new PropertyDefinitionGetResultDto
                {
                    UserKey = property.UserKey,
                    Name = property.Name,
                    NameResourceKey = property.NameResourceKey,
                    Tooltip = property.Tooltip,
                    TooltipResourceKey = property.TooltipResourceKey,
                    CrmObjectTypeId = property.CrmObjectTypeId,
                }),
                Groups = res.Groups.Select(group => new CrmObjectPropertyGroupGetResultDto
                {
                    CrmObjectTypeId = group.CrmObjectTypeId,
                    Name = group.Name,
                    NameResourceKey = group.NameResourceKey,
                    CountOfColumns = group.CountOfColumns,
                    ExpandForView = group.ExpandForView,
                }),
                Stages = res.Stages.Select(stage => new CrmObjectTypeStageGetResultDto
                {
                    CrmObjectTypeId = stage.CrmObjectTypeId,
                    Name = stage.Name,
                    NameResourceKey = stage.NameResourceKey,
                    Key = stage.Key,
                    IsDoneStage = stage.IsDoneStage,
                    IsActive = stage.IsActive,
                }),
            });
        }
    }
}
