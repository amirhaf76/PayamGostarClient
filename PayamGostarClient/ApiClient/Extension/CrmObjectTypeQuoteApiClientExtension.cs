using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeQuoteApiClientExtension
    {
        public static CrmObjectTypeQuoteCreateRequestVM ToVM(this CrmObjectTypeQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypeQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
