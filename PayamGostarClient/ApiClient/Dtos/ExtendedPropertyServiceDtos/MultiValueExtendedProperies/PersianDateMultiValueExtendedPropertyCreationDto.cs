﻿using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class PersianDateMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.PersianDateMultiValue;
    }

}
