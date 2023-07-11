using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Extensions
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
