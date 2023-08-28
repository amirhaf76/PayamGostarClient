using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create
{
    public class CrmObjectTypeInvoiceCreateRequestDto : CrmObjectTypeBaseInvoiceCreateRequestDto
    {
        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
