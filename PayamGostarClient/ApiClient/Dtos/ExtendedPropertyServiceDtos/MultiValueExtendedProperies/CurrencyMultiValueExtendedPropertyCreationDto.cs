using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class CurrencyMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CurrencyMultiValue;
    }
}
