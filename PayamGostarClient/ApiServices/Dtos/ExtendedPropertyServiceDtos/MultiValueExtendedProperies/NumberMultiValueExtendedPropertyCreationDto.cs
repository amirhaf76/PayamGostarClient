﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class NumberMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.NumberMultiValue;
        public int DecimalDigits { get; set; }

        public int? MinDigit { get; set; }

        public int? MaxDigit { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

    }
}
