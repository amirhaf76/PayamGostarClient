using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Extensions
{
    internal static class ReturnSaleInvoiceInitServiceExtension
    {
        internal static CrmObjectTypeReturnSaleInvoiceCreateRequestDto ToDto(this CrmReturnSaleInvoiceModel model)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
