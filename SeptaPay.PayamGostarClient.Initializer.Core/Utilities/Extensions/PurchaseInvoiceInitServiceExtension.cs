using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class PurchaseInvoiceInitServiceExtension
    {
        internal static CrmObjectTypePurchaseInvoiceCreateRequestDto ToDto(this CrmPurchaseInvoiceModel model)
        {
            return new CrmObjectTypePurchaseInvoiceCreateRequestDto
            {
                AutoGenerateInventoryTransaction = model.AutoGenerateInventoryTransaction,
                AutoTransactionTypeId = model.AutoTransactionTypeId,

            }.FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
