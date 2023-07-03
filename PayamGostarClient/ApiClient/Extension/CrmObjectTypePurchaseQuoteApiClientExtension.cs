using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypePurchaseQuoteApiClientExtension
    {
        public static CrmObjectTypePurchaseQuoteCreateRequestVM ToVM(this CrmObjectTypePurchaseQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypePurchaseQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
