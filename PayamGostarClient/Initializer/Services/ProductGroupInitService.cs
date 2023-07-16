using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.InitServices;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class ProductGroupInitService : IInitService
    {
        private readonly ProductGroupModel _productGroupModel;


        public ProductGroupInitService(ProductGroupModel productGroupModel, IPayamGostarApiClient payamGostarApiClient)
        {
            _productGroupModel = productGroupModel;
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            var searchingResult = await SearchProductGroupAsync();

            return searchingResult.Any();
        }

        public async Task InitAsync()
        {
            var searchingResult = await SearchProductGroupAsync();

            if (!searchingResult.Any())
            {
                await CreateProductGroupAsync();
            }
        }


        private Task<IEnumerable<object>> SearchProductGroupAsync()
        {
            throw new System.NotImplementedException();
        }

        private Task<object> CreateProductGroupAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
