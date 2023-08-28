using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class PaymentInitServiceExtension
    {
        internal static CrmObjectTypePaymentCreateRequestDto ToDto(this CrmPaymentModel model)
        {
            return new CrmObjectTypePaymentCreateRequestDto().FillCrmObjectTypeBasePaymentCreateRequestDto(model);
        }
    }
}
