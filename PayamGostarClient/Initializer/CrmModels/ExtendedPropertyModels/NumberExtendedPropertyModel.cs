﻿using PayamGostarClient.ApiClient.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class NumberExtendedPropertyModel : BaseRequireableExtendedPropertyModel
    {
        public int? MinDigits { get; set; }

        public int? MaxDigits { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

        // public int CalculationTypeIndex { get; set; }

        public int DecimalDigits { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Number;


    }
}
