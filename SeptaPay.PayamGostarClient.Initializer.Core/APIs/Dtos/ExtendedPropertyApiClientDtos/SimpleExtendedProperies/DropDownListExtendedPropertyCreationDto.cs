using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class DropDownListExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public DropDownListExtendedPropertyCreationDto()
        {
            Values = new List<DropDownListExtendedPropertyValueCreationDto>();
        }
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.DropDownList;

        public IEnumerable<DropDownListExtendedPropertyValueCreationDto> Values { get; set; }
    }


}
