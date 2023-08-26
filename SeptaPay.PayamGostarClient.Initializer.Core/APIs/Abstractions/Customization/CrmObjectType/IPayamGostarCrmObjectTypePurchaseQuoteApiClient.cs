using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypePurchaseQuoteApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePurchaseQuoteCreateRequestDto request);
    }
}
