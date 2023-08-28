using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class GregorianDateMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.GregorianDateMultiValue;
    }
}
