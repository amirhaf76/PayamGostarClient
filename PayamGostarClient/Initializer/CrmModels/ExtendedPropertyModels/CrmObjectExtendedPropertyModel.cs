using System;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public abstract class CrmObjectExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool PreventSettingContainerCrmobjectAsParent { get; set; }

        public Guid? ReferencedItemCrmObjectTypeId { get; set; }
    }
}
