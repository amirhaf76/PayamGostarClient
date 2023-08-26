using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.InitServices;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Services
{
    public class ProductGroupInitService : IInitService
    {
        private readonly ProductGroupModel _productGroupModel;
        private readonly IPayamGostarProductGroupApiClient _productGroupApi;

        public ProductGroupInitService(ProductGroupModel productGroupModel, IPayamGostarApiClient payamGostarApiClient)
        {
            _productGroupModel = productGroupModel;

            _productGroupApi = payamGostarApiClient.CustomizationApi.ProductGroupApi;
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            int matchedProductGroupCount = await GetMatchedProductGroupCount();

            if (matchedProductGroupCount > 1)
            {
                return false;
            }

            return matchedProductGroupCount == 1;
        }

        public async Task InitAsync()
        {
            int matchedProductGroupCount = await GetMatchedProductGroupCount();

            if (matchedProductGroupCount > 1)
            {
                throw new MisMatchException($"There are more than one product group with '{_productGroupModel.Name}' name in root!");
            }

            if (matchedProductGroupCount != 1)
            {
                await CreateProductGroupAsync();
            }
        }


        private async Task<int> GetMatchedProductGroupCount()
        {
            var searchingResult = await SearchProductGroupAsync();

            var matchedProductGroupCount = searchingResult
                .Where(x => x.Name == _productGroupModel.Name && x.ParentGroupId == null)
                .Count();

            return matchedProductGroupCount;
        }

        private async Task<IEnumerable<ProductGroupSearchResponseDto>> SearchProductGroupAsync()
        {
            var request = CreateGettingProductGroupRequest();

            var gettingResult = await _productGroupApi.SearchAsync(request);

            return gettingResult;
        }

        private async Task<ProductGroupCreationResponseDto> CreateProductGroupAsync()
        {
            var request = CreateProductGroupCreationRequest();

            var creationResult = await _productGroupApi.CreateAsync(request);

            return creationResult;
        }


        private ProductGroupSearchRequestDto CreateGettingProductGroupRequest()
        {
            return new ProductGroupSearchRequestDto
            {
                Name = _productGroupModel.Name,
            };
        }

        private ProductGroupCreationRequestDto CreateProductGroupCreationRequest()
        {
            return new ProductGroupCreationRequestDto
            {
                Name = _productGroupModel.Name,
            };
        }
    }
}
