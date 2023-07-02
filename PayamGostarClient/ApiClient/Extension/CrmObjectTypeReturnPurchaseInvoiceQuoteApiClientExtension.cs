using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceQuoteApiClientExtension
    {
        public static CrmObjectTypeReturnSaleInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnSaleInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
