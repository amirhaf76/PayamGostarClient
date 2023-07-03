using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
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
