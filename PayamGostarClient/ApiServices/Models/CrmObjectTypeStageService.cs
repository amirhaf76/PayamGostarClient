using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class CrmObjectTypeStageService : BaseApiService, ICrmObjectTypeStageService
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public CrmObjectTypeStageService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _crmObjectTypeStageApiClient = ClientFactory.CreateCrmObjectTypeStageApiClient();
        }

        public Task<object> CreateAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
