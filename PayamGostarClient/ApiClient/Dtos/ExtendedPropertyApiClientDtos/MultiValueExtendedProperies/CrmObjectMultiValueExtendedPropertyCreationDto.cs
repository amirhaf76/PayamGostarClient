using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
{
    public class CrmObjectMultiValueExtendedPropertyCreationDto : BaseMultiValueExtendedPropertyDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CrmObjectMultiValue;

        public int CrmObjectTypeIndex { get; set; }

        public Guid? SubTypeId { get; set; }

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }

    }
}
