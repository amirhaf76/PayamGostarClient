using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization.Category;
using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Search;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer.Abstractions.InitServices;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class CategoryInitService : IInitService
    {
        private readonly IPayamGostarCategoryApiClient _categoryApiClient;
        private readonly CategoryModel _categoryModel;


        public CategoryInitService(CategoryModel categoryModel, IPayamGostarApiClient payamGostarApiClient)
        {
            _categoryApiClient = payamGostarApiClient.CustomizationApi.CategoryApi;

            _categoryModel = categoryModel;
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            var categorySearchedResult = await SearchCategoryAsync();

            if (categorySearchedResult.Result.Count() > 1)
            {
                return false;
            }

            return categorySearchedResult.Result.Any();
        }

        public async Task InitAsync()
        {
            var categorySearchedResult = await SearchCategoryAsync();

            if (categorySearchedResult.Result.Count() > 1)
            {
                throw new MisMatchException($"There are more than one category group with '{_categoryModel.UserKey}' key!");
            }

            if (categorySearchedResult.Result.Count() != 1)
            {
                var createRequest = CreateCreationRequest(_categoryModel);

                await _categoryApiClient.CreateAsync(createRequest);
            }
        }


        private async Task<ApiResponse<IEnumerable<CategoryGetResultDto>>> SearchCategoryAsync()
        {
            var searchRequest = CreateSearchRequest(_categoryModel);

            var categorySearchedResult = await _categoryApiClient.SearchAsync(searchRequest);
            return categorySearchedResult;
        }

        private static CategorySearchRequestDto CreateSearchRequest(CategoryModel model)
        {
            return new CategorySearchRequestDto
            {
                Key = model.UserKey,
                // Name = model.Name,
            };
        }

        private static CategoryCreationRequestDto CreateCreationRequest(CategoryModel model)
        {
            return new CategoryCreationRequestDto
            {
                Name = model.Name,
                UserKey = model.UserKey,
                AddedByUser = true,
            };
        }
    }
}
