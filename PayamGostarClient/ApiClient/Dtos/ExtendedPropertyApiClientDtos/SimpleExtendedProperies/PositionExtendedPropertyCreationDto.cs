﻿using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class PositionExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Position;
    }
}
