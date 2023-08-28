using Septa.PayamGostarClient.Initializer.Core.Abstractions.InitServices;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Services
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

            if (categorySearchedResult.Count() > 1)
            {
                return false;
            }

            return categorySearchedResult.Any();
        }

        public async Task InitAsync()
        {
            var categorySearchedResult = await SearchCategoryAsync();

            if (categorySearchedResult.Count() > 1)
            {
                throw new MisMatchException($"There are more than one category group with '{_categoryModel.UserKey}' key!");
            }

            if (categorySearchedResult.Count() != 1)
            {
                var createRequest = CreateCreationRequest(_categoryModel);

                await _categoryApiClient.CreateAsync(createRequest);
            }
        }


        private async Task<IEnumerable<CategoryGetResultDto>> SearchCategoryAsync()
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
