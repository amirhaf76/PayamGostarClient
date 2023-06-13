using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class GeneralTypeExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public int? CalculationTypeIndex { get; set; }

        public bool IsRequired { get; set; }
    }



}
