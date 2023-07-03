using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create
{
    public class CrmObjectTypePurchaseInvoiceCreateRequestDto : CrmObjectTypeBaseInvoiceCreateRequestDto
    {
        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }

    }
}
