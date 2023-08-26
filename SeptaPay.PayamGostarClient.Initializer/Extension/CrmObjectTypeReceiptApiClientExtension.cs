using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReceiptApiClientExtension
    {
        public static CrmObjectTypeReceiptCreateRequestVM ToVM(this CrmObjectTypeReceiptCreateRequestDto dto)
        {
            return new CrmObjectTypeReceiptCreateRequestVM().FillCrmObjectTypePaymentCreateRequestVM(dto);
        }
    }


}
