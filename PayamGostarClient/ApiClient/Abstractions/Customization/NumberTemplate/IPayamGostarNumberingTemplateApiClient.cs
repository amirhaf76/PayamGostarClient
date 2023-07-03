using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Search;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate
{
    public interface IPayamGostarNumberingTemplateApiClient
    {
        Task<ApiResponse<NumberingTemplateCreationResultDto>> CreateAsync(NumberingTemplateCreationRequestDto request);

        Task<ApiResponse<IEnumerable<NumberingTemplateSearchResultDto>>> SearchAsync(NumberingTemplateSearchRequestDto request);

    }
}
