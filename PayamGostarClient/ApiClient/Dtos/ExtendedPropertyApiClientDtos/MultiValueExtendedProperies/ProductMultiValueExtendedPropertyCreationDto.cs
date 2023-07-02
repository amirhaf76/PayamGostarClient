using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
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
