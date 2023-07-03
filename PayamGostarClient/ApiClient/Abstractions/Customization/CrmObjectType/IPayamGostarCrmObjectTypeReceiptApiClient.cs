using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeReceiptApiClient
    {
        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeReceiptCreateRequestDto request);
    }
}
