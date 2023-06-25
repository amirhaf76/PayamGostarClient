using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class UserMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool ShowDeactiveMembersOption { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.UserMultiValue;
    }


}
