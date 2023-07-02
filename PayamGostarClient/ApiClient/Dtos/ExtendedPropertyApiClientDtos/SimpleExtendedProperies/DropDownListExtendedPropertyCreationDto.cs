using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
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
