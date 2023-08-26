using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create
{

    public abstract class BaseCrmObjectTypeCreateRequestDto
    {
        public BaseCrmObjectTypeCreateRequestDto()
        {
            EventTypes = new List<WebhookEventType>();
            Content = new CrmObjectTypeContentFilePathDto();
            Name = new SystemResourceValueDto();
            Description = new SystemResourceValueDto();
        }

        public bool AssignCustomerNumberOnApprove { get; set; }
        public bool CreateByCustomer { get; set; }
        public bool CustomerCanViewExtendedProps { get; set; }
        public bool Enabled { get; set; }
        public bool IsUnderProcess { get; set; }
        public bool LimitAccessToProcessUsers { get; set; }
        public bool ShowToCustomer { get; set; }
        public bool ViewOnlyToOwner { get; set; }

        public byte SortType { get; set; }

        public CrmObjectTypeContentFilePathDto Content { get; set; }

        public Guid? DefaultRelatedToIdentityTypeId { get; set; }
        public Guid? OwnerId { get; set; }

        public IEnumerable<WebhookEventType> EventTypes { get; set; }

        public int PreviewTypeIndex { get; set; }

        public int? AllowedDeleteDuration { get; set; }
        public int? AllowedEditDuration { get; set; }

        public string Code { get; set; }
        public string WebhookAddress { get; set; }

        public SystemResourceValueDto Description { get; set; }
        public SystemResourceValueDto Name { get; set; }

    }
}
