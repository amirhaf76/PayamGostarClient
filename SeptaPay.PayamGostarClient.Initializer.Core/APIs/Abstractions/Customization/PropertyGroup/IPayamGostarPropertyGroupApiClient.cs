using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos;

using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup
{
    public interface IPayamGostarPropertyGroupApiClient
    {
        Task<CrmObjectPropertyGroupCreationResultDto> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request);
    }
}