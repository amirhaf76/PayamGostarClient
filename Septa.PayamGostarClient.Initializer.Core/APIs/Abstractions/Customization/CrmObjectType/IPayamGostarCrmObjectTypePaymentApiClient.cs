using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypePaymentApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePaymentCreateRequestDto request);

        CrmObjectTypeResultDto Create(CrmObjectTypePaymentCreateRequestDto request);
    }
}
