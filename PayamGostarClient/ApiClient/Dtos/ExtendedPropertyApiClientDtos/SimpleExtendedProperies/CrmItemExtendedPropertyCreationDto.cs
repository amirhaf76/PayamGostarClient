using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using System;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public abstract class CrmItemExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public bool PreventSettingContainerCrmobjectAsParent { get; set; }

        public Guid? ReferencedItemCrmObjectTypeId { get; set; }
    }
}
