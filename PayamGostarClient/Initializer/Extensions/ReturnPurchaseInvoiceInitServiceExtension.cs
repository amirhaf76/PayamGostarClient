using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class ReturnPurchaseInvoiceInitServiceExtension
    {
        internal static CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto ToDto(this CrmReturnPurchaseInvoiceModel model)
        {
            return new CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
