using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos
{
    public class CrmObjectPropertyGroupCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public SystemResourceValueDto Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
