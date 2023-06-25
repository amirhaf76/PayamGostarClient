using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
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
