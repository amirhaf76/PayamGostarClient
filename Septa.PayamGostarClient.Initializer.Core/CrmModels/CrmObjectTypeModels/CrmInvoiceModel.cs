using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmInvoiceModel : CrmBaseInvoiceModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Invoice;

        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
