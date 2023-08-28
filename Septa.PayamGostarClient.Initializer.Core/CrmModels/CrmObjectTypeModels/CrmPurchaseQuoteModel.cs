using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmPurchaseQuoteModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.PurchaseQuote;

        public bool CanMultipleCloneInvoice { get; set; }

    }
}
