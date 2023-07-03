using PayamGostarClient.ApiClient.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmInvoiceModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Invoice;

        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
