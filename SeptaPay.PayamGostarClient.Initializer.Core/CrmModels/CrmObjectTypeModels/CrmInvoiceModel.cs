using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmInvoiceModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Invoice;

        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
