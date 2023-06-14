using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class SecurityItemMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.SecurityItemMultiValue;
    }

}
