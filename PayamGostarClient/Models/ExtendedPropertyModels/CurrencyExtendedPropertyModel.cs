﻿namespace PayamGostarClient.Models.ExtendedPropertyModels
{
    public class CurrencyExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool IsBalance { get; set; }

        public bool IsRequired { get; set; }

        public int CalculationTypeIndex { get; set; }
    }


}
