﻿using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class ProductMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public int FractionLength { get; set; }

        public bool ShowAmountColumn { get; set; }

        public bool ShowDiscountColumn { get; set; }

        public bool ShowUnitPriceColumn { get; set; }

        public bool ShowFinalColumn { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.ProductList;
    }


}
