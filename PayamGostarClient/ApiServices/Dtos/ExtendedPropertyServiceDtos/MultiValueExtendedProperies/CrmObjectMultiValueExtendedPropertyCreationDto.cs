﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.MultiValue;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class CrmObjectMultiValueExtendedPropertyCreationDto : BaseMultiValueExtendedPropertyDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CrmObjectMultiValue;

        public int CrmObjectTypeIndex { get; set; }

        public Guid? SubTypeId { get; set; }

        public IEnumerable<ExtendedPropertyIdWrapperDto> ShowInGridProps { get; set; }

    }
}
