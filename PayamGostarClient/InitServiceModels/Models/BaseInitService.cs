using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected T IntendedCrmObject { get; }
        protected ICrmObjectTypeService CrmObjectTypeService { get; }
        protected IPayamGostarClientServiceFactory ServiceFactory { get; }


        protected BaseInitService(T intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory)
        {
            this.IntendedCrmObject = intendedCrmObject;

            this.ServiceFactory = serviceFactory;

            CrmObjectTypeService = this.ServiceFactory.CreateCrmObjectTypeService();
        }

        public async Task InitAsync()
        {
            var existedCrmObject = await SearchCrmObjectAsync();

            if (existedCrmObject == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync(IntendedCrmObject);
            }
            else
            {
                await CheckCrmObjectTypeBelongs(IntendedCrmObject, existedCrmObject);
            }
        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync(T intendedCrmObject)
        {
            await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs();
        }

        private async Task CheckCrmObjectTypeBelongs(T intendedCrmObject, BaseCRMModel existedCrmObject)
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
            var request = ConvertToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            var receivedCrmObjects = await CrmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            return CreateSearchedCrmObjectModel(receivedCrmObject);
        }

        private static CrmObjectTypeSearchRequestDto ConvertToCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
                Name = crmMode.Name.FirstOrDefault()?.Value,
                PageSiz = 10,
                PageNumber = 1,
            };
        }

        private SearchedCrmObjectModel CreateSearchedCrmObjectModel(ApiServices.Dtos.CrmObjectTypeSearchResultDto receivedCrmObject)
        {
            return receivedCrmObject.ConvertToSearchedCrmObjectModel();
        }

        private async Task CreateCrmObjectAsync()
        {
            await CreateTypeAsync();
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


        protected abstract Task<T> CreateTypeAsync();

        protected abstract Task<T> CheckAndModifyCrmPropertiesAsync();

    }


}
