using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ReturnSaleInvoiceInitServiceExtension
    {
        internal static CrmObjectTypeReturnSaleInvoiceCreateRequestDto ToDto(this CrmReturnSaleInvoiceModel model)
        {
            return new CrmObjectTypeReturnSaleInvoiceCreateRequestDto().FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
