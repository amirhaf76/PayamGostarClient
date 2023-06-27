﻿using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class CrmItemIdentityExtendedPropertyCreationDto : CrmItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Identity;
        public bool? IsRequired { get; set; }
    }



}