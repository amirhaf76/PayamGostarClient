﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class TextMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.TextMultiValue;
    }

}