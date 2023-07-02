using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
{
    public class IdentityMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.IdentityMultiValue;

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }
    }

}
