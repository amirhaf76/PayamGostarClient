namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class GpExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.Gp;
        public string GpKey { get; set; }
    }

}
