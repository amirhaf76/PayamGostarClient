using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup
{
    public interface IPayamGostarPropertyGroupApiClient
    {
        Task<CrmObjectPropertyGroupCreationResultDto> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request);

        CrmObjectPropertyGroupCreationResultDto Create(CrmObjectPropertyGroupCreationRequestDto request);
    }
}