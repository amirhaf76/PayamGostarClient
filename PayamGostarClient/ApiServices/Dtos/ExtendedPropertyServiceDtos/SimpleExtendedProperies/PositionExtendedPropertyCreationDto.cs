﻿namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class PositionExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Position;
    }
}
