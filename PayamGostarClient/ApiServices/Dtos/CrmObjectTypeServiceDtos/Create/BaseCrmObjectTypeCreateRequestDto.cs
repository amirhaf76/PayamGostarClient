using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create
{

    public abstract class BaseCrmObjectTypeCreateRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public SystemResourceValueDto Description { get; set; }

        public string Code { get; set; }
    }

    public class SystemResourceValueDto
    {
        public string ResourceKey { get; set; }

        public IEnumerable<ResourceValueDto> ResourceValues { get; set; }
    }
}
