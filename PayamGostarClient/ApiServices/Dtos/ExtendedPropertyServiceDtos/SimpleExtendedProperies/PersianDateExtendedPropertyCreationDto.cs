﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class PersianDateExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Date;
    }


}
