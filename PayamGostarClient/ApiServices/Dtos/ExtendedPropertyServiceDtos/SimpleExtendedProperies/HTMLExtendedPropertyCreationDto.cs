using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class HTMLExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Html;
        public bool IsRequired { get; set; }
    }

}
