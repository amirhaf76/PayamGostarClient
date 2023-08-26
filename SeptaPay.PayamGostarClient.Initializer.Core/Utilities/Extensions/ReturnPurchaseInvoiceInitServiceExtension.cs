using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ReturnPurchaseInvoiceInitServiceExtension
    {
        internal static CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto ToDto(this CrmReturnPurchaseInvoiceModel model)
        {
            return new CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
