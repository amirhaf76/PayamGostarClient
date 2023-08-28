using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class CurrencyMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CurrencyMultiValue;
    }
}
