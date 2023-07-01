using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class NumberExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Number;

        public int DecimalDigits { get; set; }
        public int? MinDigits { get; set; }
        public int? MaxDigits { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

    }


}
