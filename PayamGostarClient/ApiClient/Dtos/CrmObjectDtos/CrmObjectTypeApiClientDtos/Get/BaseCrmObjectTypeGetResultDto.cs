using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get
{
    public abstract class BaseCrmObjectTypeGetResultDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CrmOjectTypeIndex { get; set; }
        public bool Enabled { get; set; }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? OwnerId { get; set; }
        public string NameResourceKey { get; set; }
        public string CrmObjectTypeName { get; set; }
        public int? ContentTypeIndex { get; set; }
        public string ContentTypeName { get; set; }
        public int? PreviewTypeIndex { get; set; }
        public string PreviewTypeName { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsBillable { get; set; }
        public bool IsUnderProcess { get; set; }
        public bool ShowToCustomer { get; set; }
        public bool LimitAccessToProcessUsers { get; set; }
        public bool ViewOnlyToOwner { get; set; }
        public int? AllowedEditDuration { get; set; }
        public int? AllowedDeleteDuration { get; set; }
        public bool CreateByCustomer { get; set; }
        public bool CustomerCanViewExtendedProps { get; set; }
        public bool IsActive { get; set; }
        public string WebhookAddress { get; set; }
        public string EventTypes { get; set; }
        public string DescriptionResourceKey { get; set; }
        public int SortType { get; set; }
        public Guid? DefaultRelatedToIdentityTypeId { get; set; }
        public Guid? ContentFileId { get; set; }
        public Guid? RankPropertyId { get; set; }


        public IEnumerable<PropertyGroupGetResultDto> Groups { get; set; }

        public IEnumerable<StageGetResultDto> Stages { get; set; }

        public IEnumerable<ExtendedPropertyGetResultDto> Properties { get; set; }

    }

}
