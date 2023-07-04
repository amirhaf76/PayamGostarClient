using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class PurchaseQuoteInitServiceExtension
    {
        internal static CrmObjectTypePurchaseQuoteCreateRequestDto ToDto(this CrmPurchaseQuoteModel model)
        {
            return new CrmObjectTypePurchaseQuoteCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
