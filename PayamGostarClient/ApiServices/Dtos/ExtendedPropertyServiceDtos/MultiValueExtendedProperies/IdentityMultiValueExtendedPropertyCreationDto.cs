using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class IdentityMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.IdentityMultiValue;

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }
    }

}
