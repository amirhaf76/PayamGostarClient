﻿using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
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
