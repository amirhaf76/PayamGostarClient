using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypePurchaseQuoteApiClientExtension
    {
        public static CrmObjectTypePurchaseQuoteCreateRequestVM ToVM(this CrmObjectTypePurchaseQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypePurchaseQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
