namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class FormExtendedPropertyCreationDto : CrmItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Form;
    }
}
