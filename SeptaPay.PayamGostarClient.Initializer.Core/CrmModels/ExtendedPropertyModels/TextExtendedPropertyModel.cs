using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class TextExtendedPropertyModel : BaseRequireableExtendedPropertyModel
    {
        /// <summary>
        /// Does not work!!! It can not be received by api.
        /// </summary>
        // public int CalculationTypeIndex { get => throw new NotSupportedByApiException(); set => throw new NotSupportedByApiException(); }

        public bool IsMultiLine { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Text;
    }


}
