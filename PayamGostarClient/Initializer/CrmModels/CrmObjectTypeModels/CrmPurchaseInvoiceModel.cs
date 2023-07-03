using PayamGostarClient.ApiClient.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmPurchaseInvoiceModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.PurchaseInvoice;

        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
