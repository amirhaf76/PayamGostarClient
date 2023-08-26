using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmPurchaseQuoteModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.PurchaseQuote;

        public bool CanMultipleCloneInvoice { get; set; }

    }
}
