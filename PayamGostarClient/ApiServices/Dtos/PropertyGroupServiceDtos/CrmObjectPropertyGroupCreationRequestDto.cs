using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using System;

namespace PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos
{
    public class CrmObjectPropertyGroupCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public SystemResourceValueDto Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
