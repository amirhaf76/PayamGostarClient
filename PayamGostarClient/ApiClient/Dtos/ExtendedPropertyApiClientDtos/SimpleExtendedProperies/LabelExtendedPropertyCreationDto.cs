using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
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
