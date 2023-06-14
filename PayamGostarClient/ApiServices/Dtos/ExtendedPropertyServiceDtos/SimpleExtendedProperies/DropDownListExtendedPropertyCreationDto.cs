﻿using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class DropDownListExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.DropDownList;

        public IEnumerable<DropDownListExtendedPropertyValueCreationDto> Values;
    }


}
