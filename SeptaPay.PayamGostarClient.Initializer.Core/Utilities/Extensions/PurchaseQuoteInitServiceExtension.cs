using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class PurchaseQuoteInitServiceExtension
    {
        internal static CrmObjectTypePurchaseQuoteCreateRequestDto ToDto(this CrmPurchaseQuoteModel model)
        {
            return new CrmObjectTypePurchaseQuoteCreateRequestDto
            {
                CanMultipleCloneInvoice = model.CanMultipleCloneInvoice,

            }.FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
