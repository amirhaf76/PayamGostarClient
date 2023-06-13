namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class TextExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.Text;
        public bool? IsMultiline { get; set; }
    }
     

}
