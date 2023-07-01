using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using System;

namespace PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos
{
    public class CrmObjectPropertyGroupCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public SystemResourceValueDto Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
