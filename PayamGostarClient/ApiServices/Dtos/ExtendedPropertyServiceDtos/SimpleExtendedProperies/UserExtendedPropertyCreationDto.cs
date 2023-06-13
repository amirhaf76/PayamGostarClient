namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class UserExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.User;
        public bool? ShowDeactiveMembersOption { get; set; }
    }
     

}
