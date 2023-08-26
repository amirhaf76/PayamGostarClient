using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceQuoteApiClientExtension
    {
        public static CrmObjectTypeReturnSaleInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnSaleInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
