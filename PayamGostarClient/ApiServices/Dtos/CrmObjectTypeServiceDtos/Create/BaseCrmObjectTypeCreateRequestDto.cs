using System;
using System.Text;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create
{

    public abstract class BaseCrmObjectTypeCreateRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public SystemResourceValueDto Description { get; set; }

        public string Code { get; set; }

        public int PreviewTypeIndex { get; set; }
    }
}
