using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeQuoteApiClient
    {
        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeQuoteCreateRequestDto request);
    }
}
