namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class TextExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Text;
        public bool? IsMultiline { get; set; }
    }
     

}
