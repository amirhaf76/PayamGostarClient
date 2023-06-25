using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class LabelExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Label;

        public int? CalculationTypeIndex { get; set; }

        public string LabelText { get; set; }

        public int? ColorId { get; set; }

        public int ShowTitleTypeIndex { get; set; }

        public string IconName { get; set; }

    }


}
