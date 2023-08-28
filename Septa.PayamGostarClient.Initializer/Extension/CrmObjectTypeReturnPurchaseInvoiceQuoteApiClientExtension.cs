using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReturnPurchaseInvoiceQuoteApiClientExtension
    {
        public static CrmObjectTypeReturnSaleInvoiceCreateRequestVM ToVM(this CrmObjectTypeReturnSaleInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
