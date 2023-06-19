using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos
{
    public class SystemResourceValueDto
    {
        public SystemResourceValueDto()
        {
            ResourceValues = new List<ResourceValueDto>();
        }

        public string ResourceKey { get; set; }

        public IEnumerable<ResourceValueDto> ResourceValues { get; set; }
    }
}
