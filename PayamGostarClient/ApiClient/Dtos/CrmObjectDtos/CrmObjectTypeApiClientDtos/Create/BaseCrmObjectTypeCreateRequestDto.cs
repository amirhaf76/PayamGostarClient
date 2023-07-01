using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using System;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create
{

    public abstract class BaseCrmObjectTypeCreateRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public SystemResourceValueDto Description { get; set; }

        public string Code { get; set; }

        public int PreviewTypeIndex { get; set; }

        public bool Enabled { get; set; }
    }
}
