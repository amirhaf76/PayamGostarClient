using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class ExtendedPropertyService : BaseApiService, IExtendedPropertyService
    {
        private readonly IPropertyDefinitionApiClient _propertyDefinitionApiClient;
        private readonly ExtendedPropertyCreationFactory _extendedFactory;


        public ExtendedPropertyService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyDefinitionApiClient = ClientFactory.CreatePropertyDefinitionApiClient();

            _extendedFactory = new ExtendedPropertyCreationFactory(clientFactory); 
        }

        public async Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync(BaseExtendedPropertyDto baseProperty)
        {
            var extendedPropertyCreationService = _extendedFactory.Create(baseProperty);

            return await extendedPropertyCreationService.CreateAsync();
        }
    }
}
