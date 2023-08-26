using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos
{
    public class SystemResourceValueDto
    {
        public SystemResourceValueDto()
        {
            ResourceValues = new List<ResourceValueDto>();
        }

        public string ResourceKey { get; set; }

        public IEnumerable<ResourceValueDto> ResourceValues { get; set; }

        public override string ToString()
        {
            return Helper.Help.GetStringsFromProperties(this);
        }
    }
}
