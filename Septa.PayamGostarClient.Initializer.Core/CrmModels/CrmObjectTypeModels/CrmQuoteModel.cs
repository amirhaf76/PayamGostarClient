using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmQuoteModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Quote;

        public bool CanMultipleCloneInvoice { get; set; }

    }
}
