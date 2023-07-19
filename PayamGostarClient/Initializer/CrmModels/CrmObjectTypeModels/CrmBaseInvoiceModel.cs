using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public abstract class CrmBaseInvoiceModel : BaseCRMModel, INumericalCrmModel
    {
        public CrmBaseInvoiceModel()
        {
            NumberingTemplate = new NumberingTemplateModel();
        }


        public bool AllowDuplicateProductIdsInDetails { get; set; }
        public bool CanChangeTotalDiscount { get; set; }
        public bool CanChangeTotalTax { get; set; }
        public bool CanChangeTotalToll { get; set; }
        public bool ChangeToStatePendingOnUpdate { get; set; }
        public bool DisableDecimalCalculation { get; set; }
        public bool NeedApproval { get; set; }
        public bool NeedNumbering { get; set; }

        public int CountDecimalDigits { get; set; }
        public int Toll { get; set; }
        public int Tax { get; set; }

        public string TotalPriceFormulaCalculation { get; set; }
        public string SignaturePath { get; set; }

        public NumberingTemplateModel NumberingTemplate { get; set; }

        public AdditionalCostModel AdditionalCosts { get; set; }

        internal bool HasAdditionalCosts => AdditionalCosts != null;

    }
}
