using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class CurrencyExtendedPropertyModel : BaseRequireableExtendedPropertyModel
    {
        public bool IsBalance { get; internal set; }

        // public int CalculationTypeIndex { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Currency;
    }
}
