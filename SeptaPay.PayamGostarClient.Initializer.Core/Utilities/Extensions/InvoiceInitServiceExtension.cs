using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{

    internal static class InvoiceInitServiceExtension
    {
        internal static CrmObjectTypeInvoiceCreateRequestDto ToDto(this CrmInvoiceModel model)
        {
            return new CrmObjectTypeInvoiceCreateRequestDto
            {
                AutoGenerateInventoryTransaction = model.AutoGenerateInventoryTransaction,
                AutoTransactionTypeId = model.AutoTransactionTypeId,

            }.FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
