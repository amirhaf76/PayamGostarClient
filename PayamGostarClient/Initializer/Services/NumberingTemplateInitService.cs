using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Search;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class NumberingTemplateInitService : IInitService
    {
        private readonly IPayamGostarNumberingTemplateApiClient _numberingTemplateApiClient;
        private readonly NumberingTemplateModel _numberingTemplateModel;


        public NumberingTemplateInitService(NumberingTemplateModel model, IPayamGostarApiClient payamGostarApiClient)
        {
            _numberingTemplateModel = model;

            _numberingTemplateApiClient = payamGostarApiClient.CustomizationApi.NumberingTemplateApi;
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            var numberingTemplatesResponse = await SearchNumberingTemplate(_numberingTemplateModel);

            if (numberingTemplatesResponse.Result.Count() > 1)
            {
                throw CreateExceptionForMoreThanOneSimilarNumberingTemplate(numberingTemplatesResponse.Result);
            }

            return numberingTemplatesResponse.Result.Count() == 1;
        }

        public async Task InitAsync()
        {
            var numberingTemplatesResponse = await SearchNumberingTemplate(_numberingTemplateModel);

            if (numberingTemplatesResponse.Result.Count() > 1)
            {
                throw CreateExceptionForMoreThanOneSimilarNumberingTemplate(numberingTemplatesResponse.Result);
            }

            if (!numberingTemplatesResponse.Result.Any())
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.CreateAsync(_numberingTemplateModel.ToDto());

                _numberingTemplateModel.Id = numberingTemplateCreationResult.Result.NumberingTemplateId;
            }
        }


        private async Task<ApiResponse<IEnumerable<NumberingTemplateSearchResultDto>>> SearchNumberingTemplate(NumberingTemplateModel model)
        {
            return await _numberingTemplateApiClient.SearchAsync(new NumberingTemplateSearchRequestDto
            {
                Name = model.Name,
                Prefix = model.Prefix,
            });
        }

        private static MoreThanOneSimilarNumberingTemplateException CreateExceptionForMoreThanOneSimilarNumberingTemplate(IEnumerable<NumberingTemplateSearchResultDto> numberingTemplates)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("NumberingTemplates:");

            foreach (var numberingTemplate in numberingTemplates)
            {
                strBuilder.AppendLine($"\t- Id: {numberingTemplate.Id}, Name: {numberingTemplate.Name}, Prefix: {numberingTemplate.Prefix}");
            }

            throw new MoreThanOneSimilarNumberingTemplateException($"There are more than one similar numbering template!\n{strBuilder}");
        }

    }

}
