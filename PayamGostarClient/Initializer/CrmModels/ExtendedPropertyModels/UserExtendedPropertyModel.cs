using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class UserExtendedPropertyModel : BaseExtendedPropertyModel
    {
        //public bool ShowDeactiveMembersOption { get; set; }

        // public bool IsRequired { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.User;
    }
}
