﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class ColorExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override ExtendedPropertyType Type => ExtendedPropertyType.Color;
    }

    

}