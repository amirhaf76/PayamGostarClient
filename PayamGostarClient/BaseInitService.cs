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

        private async Task CheckCrmObjectTypeBelongs()
        {
            await CheckPropetiesDefinitionAsync();

            await CheckGroupPropetiesAsync();

            await CheckStagesAsync();
        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            await CreateCrmObjectAsync();

            await CheckCrmObjectTypeBelongs();
        }

        private Task CheckStagesAsync()
        {
            throw new NotImplementedException();
        }

        private Task CreateCrmObjectAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckGroupPropetiesAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckPropetiesDefinitionAsync()
        {
            throw new NotImplementedException();
        }

        private Task<object> SearchCrmObjectAsync()
        {
            throw new NotImplementedException();
        }


        protected abstract T CreateType();
    }


}
