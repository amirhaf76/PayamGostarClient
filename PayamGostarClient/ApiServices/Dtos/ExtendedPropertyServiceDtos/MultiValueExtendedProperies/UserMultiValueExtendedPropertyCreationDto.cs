using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class UserMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public bool? ShowDeactiveMembersOption { get; set; }
    }

}
