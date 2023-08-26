using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class PositionExtendedPropertyModel : BaseSequrityExtendedPropertyModel
    {
        // public bool IsRequired { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Position;
    }


}
