using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
