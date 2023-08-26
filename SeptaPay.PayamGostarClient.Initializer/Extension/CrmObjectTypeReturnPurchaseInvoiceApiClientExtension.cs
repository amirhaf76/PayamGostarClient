using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceApiClientExtension
    {
        public static CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
