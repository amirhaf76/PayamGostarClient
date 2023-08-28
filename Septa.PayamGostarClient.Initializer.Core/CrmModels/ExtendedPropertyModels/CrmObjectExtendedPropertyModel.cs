using System;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public abstract class CrmObjectExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool PreventSettingContainerCrmobjectAsParent { get; set; }

        public Guid? ReferencedItemCrmObjectTypeId { get; set; }
    }
}
