using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypePurchaseQuoteApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePurchaseQuoteCreateRequestDto request);

        CrmObjectTypeResultDto Create(CrmObjectTypePurchaseQuoteCreateRequestDto request);
    }
}
