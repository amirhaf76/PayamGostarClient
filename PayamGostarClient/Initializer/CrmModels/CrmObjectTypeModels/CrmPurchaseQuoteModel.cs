using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmPurchaseQuoteModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.PurchaseQuote;

        public bool CanMultipleCloneInvoice { get; set; }

    }
}
