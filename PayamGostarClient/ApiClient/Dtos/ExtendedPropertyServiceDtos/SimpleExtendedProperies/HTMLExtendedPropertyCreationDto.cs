﻿using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class HTMLExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Html;
        public bool IsRequired { get; set; }
    }

}
