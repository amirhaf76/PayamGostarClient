using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeReceiptApiClientExtension
    {
        public static CrmObjectTypeReceiptCreateRequestVM ToVM(this CrmObjectTypeReceiptCreateRequestDto dto)
        {
            return new CrmObjectTypeReceiptCreateRequestVM().FillCrmObjectTypePaymentCreateRequestVM(dto);
        }
    }


}
