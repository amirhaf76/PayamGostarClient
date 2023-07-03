namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public abstract class CrmBaseInvoiceModel : BaseCRMModel
    {
        public int NumberingTemplateId { get; set; }
        public int Vat { get; set; }
        public int Toll { get; set; }
        public bool NeedApproval { get; set; }
        public bool NeedNumbering { get; set; }
        public bool ChangeToStatePendingOnUpdate { get; set; }
        public bool DisableDecimalCalculation { get; set; }
        public bool CanChangeTotalDiscount { get; set; }
        public bool CanChangeTotalTax { get; set; }
        public bool CanChangeTotalToll { get; set; }
        public int CountDecimalDigits { get; set; }
        public bool AllowDuplicateProductIdsInDetails { get; set; }
        public bool HasAdditionalCosts { get; set; }
        public int? AdditionalCostsPlacementTypeIndex { get; set; }
        public string AdditionalCostsTitle { get; set; }
        public bool AdditionalCostIncludedTax { get; set; }
        public bool AdditionalCostIncludedToll { get; set; }
        public int? AdditionalCostsTypeIndex { get; set; }
        public decimal? AdditionalCosts { get; set; }
        public string BasePriceFormula { get; set; }
        public bool CanMultipleCloneInvoice { get; set; }
        public string SignaturePath { get; set; }

    }
}
