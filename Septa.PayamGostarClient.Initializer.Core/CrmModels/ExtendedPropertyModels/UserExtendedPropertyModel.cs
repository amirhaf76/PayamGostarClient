using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class UserExtendedPropertyModel : BaseSequrityExtendedPropertyModel
    {
        //public bool ShowDeactiveMembersOption { get; set; }

        // public bool IsRequired { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.User;
    }
}
