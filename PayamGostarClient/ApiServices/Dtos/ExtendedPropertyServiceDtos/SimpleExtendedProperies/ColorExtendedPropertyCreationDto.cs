using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class ColorExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Color;
    }

    

}
