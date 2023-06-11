using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.Models;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected BaseCRMModel BaseCrmModel { get; }

        private readonly ICrmObjectTypeApiService _crmObjectTypeApiService;

        protected BaseInitService(BaseCRMModel baseCrmModel, ICrmObjectTypeApiService crmObjectTypeApiService)
        {
            BaseCrmModel = baseCrmModel;

            _crmObjectTypeApiService = crmObjectTypeApiService;
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
            await CheckPropetiesDefinitionAsync();

            await CheckGroupPropetiesAsync();

            await CheckStagesAsync();
        }

        private async Task CreateCrmObjectTypeBelongs()
        {
            await CreatePropetiesDefinitionAsync();

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

        private async Task CheckPropetiesDefinitionAsync()
        {
            if (false)
            {

            }

            await CreatePropetiesDefinitionAsync();
        }


        private Task<object> SearchCrmObjectAsync()
        {
            throw new NotImplementedException();
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

        private Task CreatePropetiesDefinitionAsync()
        {
            throw new NotImplementedException();
        }


        protected abstract T CreateType();
    }


}
