using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class NumberExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Number;

        public int DecimalDigits { get; set; }
        public int? MinDigits { get; set; }
        public int? MaxDigits { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

    }


}
