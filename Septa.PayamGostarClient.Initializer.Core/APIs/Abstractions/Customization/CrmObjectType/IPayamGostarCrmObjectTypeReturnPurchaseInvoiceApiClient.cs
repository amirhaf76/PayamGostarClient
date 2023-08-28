using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto request);

    }
}
