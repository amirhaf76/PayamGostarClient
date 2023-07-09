using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class PaymentInitServiceExtension
    {
        internal static CrmObjectTypePaymentCreateRequestDto ToDto(this CrmPaymentModel model)
        {
            return new CrmObjectTypePaymentCreateRequestDto().FillCrmObjectTypeBasePaymentCreateRequestDto(model);
        }
    }
}
