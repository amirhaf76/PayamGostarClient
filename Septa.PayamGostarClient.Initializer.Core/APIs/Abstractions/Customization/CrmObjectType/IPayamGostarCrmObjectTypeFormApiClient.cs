using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Gets;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeFormApiClient
    {
        Task<CrmObjectTypeFormGetResultDto> GetAsync(CrmObjectTypeGetRequestDto request);

        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeFormCreateRequestDto request);


        CrmObjectTypeFormGetResultDto Get(CrmObjectTypeGetRequestDto request);

        CrmObjectTypeResultDto Create(CrmObjectTypeFormCreateRequestDto request);
    }
}