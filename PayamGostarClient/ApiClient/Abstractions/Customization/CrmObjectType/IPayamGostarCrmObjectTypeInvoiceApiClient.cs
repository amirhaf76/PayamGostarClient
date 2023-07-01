using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeInvoiceApiClient
    {
        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeInvoiceCreateRequestDto request);

        Task<ApiResponse<IEnumerable<AdditionalCostsPlacementTypeGetResultDto>>> GetAdditionalCostsPlacementTypeAsync();

        Task<ApiResponse<IEnumerable<InvoiceAdditionalCostTypeGetResultDto>>> GetAdditionalCostTypeAsync();
    }
}