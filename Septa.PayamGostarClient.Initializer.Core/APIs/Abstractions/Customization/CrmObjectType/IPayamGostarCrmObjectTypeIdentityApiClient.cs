using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeIdentityApiClient
    {
        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeIdentityCreationRequestDto request);

        Task<IEnumerable<ProfileTypeGetResultDto>> GetProfileTypeAsync();


        CrmObjectTypeResultDto Create(CrmObjectTypeIdentityCreationRequestDto request);

        IEnumerable<ProfileTypeGetResultDto> GetProfileType();
    }
}