using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class AdditionalCostModel
    {
        public string AdditionalCostsTitle { get; set; }

        public Gp_AdditionalCostsPlacementType AdditionalCostsPlacement { get; set; }
        public Gp_InvoiceAdditionalCostType InvoiceAdditionalCost { get; set; }

        public bool AdditionalCostIncludedTax { get; set; }
        public bool AdditionalCostIncludedToll { get; set; }

        public decimal AdditionalCostsAmount { get; set; }
    }


}
