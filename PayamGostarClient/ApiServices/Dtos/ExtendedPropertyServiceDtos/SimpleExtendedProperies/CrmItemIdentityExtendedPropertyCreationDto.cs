namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class CrmItemIdentityExtendedPropertyCreationDto : CrmItemExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.CrmItemIdentity;
        public bool? IsRequired { get; set; }
    }



}
