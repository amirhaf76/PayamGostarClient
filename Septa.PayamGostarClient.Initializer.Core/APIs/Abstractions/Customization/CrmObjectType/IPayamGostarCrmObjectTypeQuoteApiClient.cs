using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeQuoteApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeQuoteCreateRequestDto request);

        CrmObjectTypeResultDto Create(CrmObjectTypeQuoteCreateRequestDto request);
    }
}
