using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate
{
    public interface IPayamGostarNumberingTemplateApiClient
    {
        Task<NumberingTemplateCreationResultDto> CreateAsync(NumberingTemplateCreationRequestDto request);

        Task<IEnumerable<NumberingTemplateSearchResultDto>> SearchAsync(NumberingTemplateSearchRequestDto request);

    }
}
