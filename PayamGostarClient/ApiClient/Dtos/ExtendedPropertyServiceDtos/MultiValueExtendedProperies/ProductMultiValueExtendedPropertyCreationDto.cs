﻿using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class ProductMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.ProductList;

        public int FractionLength { get; set; }

        public bool ShowAmountColumn { get; set; }

        public bool ShowDiscountColumn { get; set; }

        public bool ShowUnitPriceColumn { get; set; }

        public bool ShowFinalPriceColumn { get; set; }

    }

}
