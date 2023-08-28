using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceApiClientExtension
    {
        public static CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnPurchaseInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
