using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Extensions
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
