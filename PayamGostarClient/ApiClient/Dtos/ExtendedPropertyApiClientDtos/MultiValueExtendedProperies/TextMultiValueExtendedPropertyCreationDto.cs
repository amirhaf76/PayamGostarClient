using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
{
    public class TextMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.TextMultiValue;
    }

}
