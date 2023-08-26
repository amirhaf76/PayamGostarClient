using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ReceiptInitServiceExtension
    {
        internal static CrmObjectTypeReceiptCreateRequestDto ToDto(this CrmReceiptModel model)
        {
            return new CrmObjectTypeReceiptCreateRequestDto().FillCrmObjectTypeBasePaymentCreateRequestDto(model);
        }
    }
}
