using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class NumberMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.NumberMultiValue;

        public int DecimalDigits { get; set; }

        public int? MinDigit { get; set; }

        public int? MaxDigit { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }
    }
}
