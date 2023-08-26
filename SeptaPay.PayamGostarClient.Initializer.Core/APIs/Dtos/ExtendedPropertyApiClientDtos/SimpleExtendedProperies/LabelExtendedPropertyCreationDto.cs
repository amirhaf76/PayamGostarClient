using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
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
