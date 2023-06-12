using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected BaseCRMModel BaseCrmModel { get; }

        private readonly ICrmObjectTypeApiService _crmObjectTypeService;


        protected BaseInitService(BaseCRMModel baseCrmModel, IPayamGostarClientServiceFactory serviceFactory)
        {
            BaseCrmModel = baseCrmModel;

            _crmObjectTypeService = serviceFactory.CreateCrmObjectTypeApiService();
        }

        public async Task InitAsync<T1>() where T1 : BaseCRMModel
        {
            var searchingResult = await SearchCrmObjectAsync();

            if (searchingResult == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync();
            }
            else
            {
                await CheckCrmObjectTypeBelongs();
            }
        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs();
        }

        private async Task CheckCrmObjectTypeBelongs()
        {

            await CheckExtendedPropertiesAsync();

            await CheckGroupPropetiesAsync();

            await CheckStagesAsync();
        }

        private async Task CreateCrmObjectTypeBelongs()
        {
            await CreateExtendedPropertiesAsync();

            await CreateGroupPropetiesAsync();

            await CreateStagesAsync();
        }


        private async Task CheckStagesAsync()
        {
            if (false)
            {

            }

            await CreateStagesAsync();
        }

        private async Task CheckGroupPropetiesAsync()
        {
            if (false)
            {

            }

            await CreateGroupPropetiesAsync();
        }

        private async Task CheckExtendedPropertiesAsync()
        {
            if (false)
            {

            }

            await CreateExtendedPropertiesAsync();
        }


        private async Task<SearchedCrmObjectModel> SearchCrmObjectAsync()
        {
            var request = BaseCrmModel.ConvertToBaseCrmModelDto();

            var receivedCrmObjects = await _crmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            return CreateSearchedCrmObjectModel(receivedCrmObject);
        }

        private SearchedCrmObjectModel CreateSearchedCrmObjectModel(ApiServices.Dtos.CrmObjectTypeGetResultDto receivedCrmObject)
        {
            return receivedCrmObject.ConvertToSearchedCrmObjectModel();
        }

        private Task CreateCrmObjectAsync()
        {
            throw new NotImplementedException();
        }

        private Task CreateStagesAsync()
        {
            throw new NotImplementedException();
        }

        private Task CreateGroupPropetiesAsync()
        {
            throw new NotImplementedException();
        }

        private Task CreateExtendedPropertiesAsync()
        {
            throw new NotImplementedException();
        }


        protected abstract T CreateType();

        //protected abstract T CheckAndModifyCrmProperties(T currentModel);

    }


}
