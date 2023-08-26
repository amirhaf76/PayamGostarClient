using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class UserExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.User;
        public bool? ShowDeactiveMembersOption { get; set; }
    }


}
