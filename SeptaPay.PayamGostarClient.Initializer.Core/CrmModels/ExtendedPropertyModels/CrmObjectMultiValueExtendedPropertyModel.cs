using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class CrmObjectMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public CrmObjectMultiValueExtendedPropertyModel()
        {
            ShowInGridProps = Array.Empty<PropertyDefinitionIdWrapperModel>();
        }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CrmObjectMultiValue;

        public Gp_CrmObjectType CrmObjectTypeIndex { get; set; }

        public string SubTypeId { get; set; }

        public PropertyDefinitionIdWrapperModel[] ShowInGridProps { get; set; }
    }
}
