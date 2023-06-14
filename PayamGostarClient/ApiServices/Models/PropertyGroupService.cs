using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class PropertyGroupService : BaseApiService, IPropertyGroupService
    {
        private readonly IPropertyGroupApiClient _propertyGroupApiClient;

        public PropertyGroupService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyGroupApiClient = ClientFactory.CreatePropertyGroupApiClient();
        }

        public Task<object> CreateAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
