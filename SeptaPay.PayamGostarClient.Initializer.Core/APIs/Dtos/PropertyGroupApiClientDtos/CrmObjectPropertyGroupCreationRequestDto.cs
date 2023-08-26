using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos
{
    public class CrmObjectPropertyGroupCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public SystemResourceValueDto Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
