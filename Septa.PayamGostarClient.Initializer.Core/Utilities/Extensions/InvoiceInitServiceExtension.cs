using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
