using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
{
    public class IdentityMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public IdentityMultiValueExtendedPropertyCreationDto()
        {
            ShowInGridProps = new List<ExtendedPropertyIdWrapperDto>();
        }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.IdentityMultiValue;

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }
    }

}
