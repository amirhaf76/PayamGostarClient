using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Extensions
{
    internal static class ReceiptInitServiceExtension
    {
        internal static CrmObjectTypeReceiptCreateRequestDto ToDto(this CrmReceiptModel model)
        {
            return new CrmObjectTypeReceiptCreateRequestDto().FillCrmObjectTypeBasePaymentCreateRequestDto(model);
        }
    }
}
