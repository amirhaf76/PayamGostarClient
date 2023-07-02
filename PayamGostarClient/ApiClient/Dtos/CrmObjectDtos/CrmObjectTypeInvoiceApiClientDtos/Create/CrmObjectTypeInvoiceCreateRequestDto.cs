using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create
{
    public class CrmObjectTypeInvoiceCreateRequestDto : BaseCrmObjectTypeInvoiceCreateRequestDto
    {
        public bool AutoGenerateInventoryTransaction { get; set; }

        public Guid? AutoTransactionTypeId { get; set; }
    }
}
