using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class TimeExtendedPropertyModel : BaseRequireableExtendedPropertyModel
    {
        //public int CalculationTypeIndex { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Time;
    }


}
