using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceApiClientExtension
    {
        public static CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
