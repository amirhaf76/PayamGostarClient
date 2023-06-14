namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class GpExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Group;
        public string GpKey { get; set; }
    }

}
