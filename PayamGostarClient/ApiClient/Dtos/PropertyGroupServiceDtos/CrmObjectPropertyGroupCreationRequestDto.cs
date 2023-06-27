using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using System;

namespace PayamGostarClient.ApiClient.Dtos.PropertyGroupServiceDtos
{
    public class CrmObjectPropertyGroupCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public SystemResourceValueDto Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
