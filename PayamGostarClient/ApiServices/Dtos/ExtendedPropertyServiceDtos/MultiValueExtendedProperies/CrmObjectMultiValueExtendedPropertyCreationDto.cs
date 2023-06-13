using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class CrmObjectMultiValueExtendedPropertyCreationDto : BaseMultiValueExtendedPropertyDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.CrmObjectMultiValue;
        public Guid CrmObjectTypeId { get; set; }
        public int CrmObjectTypeIndex { get; set; }
        public Guid? SubTypeId { get; set; }
        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }

    }
}
