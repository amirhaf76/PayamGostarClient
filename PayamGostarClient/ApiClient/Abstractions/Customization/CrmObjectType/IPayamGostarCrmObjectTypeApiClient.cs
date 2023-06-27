using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiClient.Models;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCrmObjectTypeApiClient
    {
        IPayamGostarCrmObjectTypeFormApiClient FormApi { get; }
        IPayamGostarCrmObjectTypeStageApiClient StageApi { get; }
        IPayamGostarCrmObjectTypeTicketApiClient TicketApi { get; }

        Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchAsync(CrmObjectTypeSearchRequestDto request);
    }
}