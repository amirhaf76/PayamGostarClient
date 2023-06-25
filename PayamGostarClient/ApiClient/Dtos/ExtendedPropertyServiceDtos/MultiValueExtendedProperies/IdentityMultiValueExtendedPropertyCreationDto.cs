using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class IdentityMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.IdentityMultiValue;

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }
    }

}
