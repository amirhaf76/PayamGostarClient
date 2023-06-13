using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class LabelExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.Label;

        public int? CalculationTypeIndex { get; set; }

        public string LabelText { get; set; }

        public int? ColorId { get; set; }

        public int ShowTitleTypeIndex { get; set; }

        public string IconName { get; set; }

    }
     

}
