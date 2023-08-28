using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public abstract class CrmItemExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public bool PreventSettingContainerCrmobjectAsParent { get; set; }

        public Guid? ReferencedItemCrmObjectTypeId { get; set; }
    }
}
