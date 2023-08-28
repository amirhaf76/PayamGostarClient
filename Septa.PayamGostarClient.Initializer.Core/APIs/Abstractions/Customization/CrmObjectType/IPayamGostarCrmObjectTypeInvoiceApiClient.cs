using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeInvoiceApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeInvoiceCreateRequestDto request);

        Task<IEnumerable<AdditionalCostsPlacementTypeGetResultDto>> GetAdditionalCostsPlacementTypeAsync();

        Task<IEnumerable<InvoiceAdditionalCostTypeGetResultDto>> GetAdditionalCostTypeAsync();
    }
}