using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeReturnInvoiceApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReturnSaleInvoiceCreateRequestDto request);
    }
}
