namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class CrmItemIdentityExtendedPropertyCreationDto : CrmItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Identity;
        public bool? IsRequired { get; set; }
    }



}
