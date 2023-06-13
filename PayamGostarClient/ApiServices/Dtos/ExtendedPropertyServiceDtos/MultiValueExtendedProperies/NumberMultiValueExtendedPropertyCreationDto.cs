using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class NumberMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.NumberMultiValue;
        public int DecimalDigits { get; set; }

        public int? MinDigit { get; set; }

        public int? MaxDigit { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

    }
}
