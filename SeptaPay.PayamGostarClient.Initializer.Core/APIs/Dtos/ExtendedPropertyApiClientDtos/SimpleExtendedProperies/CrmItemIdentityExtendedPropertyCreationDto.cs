using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class CrmItemIdentityExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Identity;
    }



}
