using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeReturnInvoiceApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReturnSaleInvoiceCreateRequestDto request);
    }
}
