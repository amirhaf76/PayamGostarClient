using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ReturnSaleInvoiceInitServiceExtension
    {
        internal static CrmObjectTypeReturnSaleInvoiceCreateRequestDto ToDto(this CrmReturnSaleInvoiceModel model)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
