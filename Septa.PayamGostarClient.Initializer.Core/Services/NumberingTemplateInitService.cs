using Septa.PayamGostarClient.Initializer.Core.Abstractions.InitServices;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Services
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

            if (numberingTemplatesResponse.Count() > 1)
            {
                throw CreateExceptionForMoreThanOneSimilarNumberingTemplate(numberingTemplatesResponse);
            }

            return numberingTemplatesResponse.Count() == 1;
        }

        public async Task InitAsync()
        {
            var numberingTemplatesResponse = await SearchNumberingTemplate(_numberingTemplateModel);

            if (numberingTemplatesResponse.Count() > 1)
            {
                throw CreateExceptionForMoreThanOneSimilarNumberingTemplate(numberingTemplatesResponse);
            }

            if (!numberingTemplatesResponse.Any())
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.CreateAsync(_numberingTemplateModel.ToDto());

                _numberingTemplateModel.Id = numberingTemplateCreationResult.NumberingTemplateId;
            }
            else
            {
                _numberingTemplateModel.Id = numberingTemplatesResponse.FirstOrDefault()?.Id;
            }
        }


        private async Task<IEnumerable<NumberingTemplateSearchResultDto>> SearchNumberingTemplate(NumberingTemplateModel model)
        {
            return await _numberingTemplateApiClient.SearchAsync(new NumberingTemplateSearchRequestDto
            {
                Name = model.Name,
                Prefix = model.Prefix,
                InitialSeed = model.InitialSeed,
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
