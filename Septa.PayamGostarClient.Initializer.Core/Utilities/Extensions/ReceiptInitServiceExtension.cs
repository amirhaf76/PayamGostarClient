using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ReceiptInitServiceExtension
    {
        internal static CrmObjectTypeReceiptCreateRequestDto ToDto(this CrmReceiptModel model)
        {
            return new CrmObjectTypeReceiptCreateRequestDto().FillCrmObjectTypeBasePaymentCreateRequestDto(model);
        }
    }
}
