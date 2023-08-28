using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypePurchaseInvoiceApiClientExtension
    {
        public static CrmObjectTypePurchaseInvoiceCreateRequestVM ToVM(this CrmObjectTypePurchaseInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypePurchaseInvoiceCreateRequestVM
            {
                AutoGenerateInventoryTransaction = dto.AutoGenerateInventoryTransaction,
                AutoTransactionTypeId = dto.AutoTransactionTypeId,

            }.FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }


}
