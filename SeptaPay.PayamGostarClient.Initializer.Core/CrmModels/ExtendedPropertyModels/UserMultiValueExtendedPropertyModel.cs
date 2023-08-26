using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class UserMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool ShowDeactiveMembersOption { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.UserMultiValue;
    }


}
