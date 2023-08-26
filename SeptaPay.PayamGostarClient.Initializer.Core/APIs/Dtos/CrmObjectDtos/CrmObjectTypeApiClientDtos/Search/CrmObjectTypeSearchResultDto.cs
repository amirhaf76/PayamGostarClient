using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search
{
    public class CrmObjectTypeSearchResultDto
    {
        public CrmObjectTypeSearchResultDto()
        {
            Groups = new List<PropertyGroupGetResultDto>();
            Stages = new List<StageGetResultDto>();
            Properties = new List<ExtendedPropertyGetResultDto>();

        }
        public System.Guid Id { get; set; }
        public System.Guid? ParentId { get; set; }
        public System.Guid? OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CrmOjectTypeIndex { get; set; }
        public int? NumberingTemplateId { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsUnderProcess { get; set; }
        public bool Enabled { get; set; }

        public IEnumerable<PropertyGroupGetResultDto> Groups { get; set; }

        public IEnumerable<StageGetResultDto> Stages { get; set; }

        public IEnumerable<ExtendedPropertyGetResultDto> Properties { get; set; }

    }
}
