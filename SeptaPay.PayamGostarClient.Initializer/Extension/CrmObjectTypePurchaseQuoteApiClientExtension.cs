using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypePurchaseQuoteApiClientExtension
    {
        public static CrmObjectTypePurchaseQuoteCreateRequestVM ToVM(this CrmObjectTypePurchaseQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypePurchaseQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
