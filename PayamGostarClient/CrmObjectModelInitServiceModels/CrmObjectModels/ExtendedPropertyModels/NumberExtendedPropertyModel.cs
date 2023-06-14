using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class NumberExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public int MinDigits {get; set; }

        public int MaxDigits { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public bool IsRequired { get; set; }

        public int CalculationTypeIndex { get; set; }

        public string CrmObjectTypeId { get; set; }

        public int DecimalDigits { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Number;
    }
}
