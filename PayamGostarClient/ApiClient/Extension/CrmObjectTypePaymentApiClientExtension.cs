using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypePaymentApiClientExtension
    {
        public static CrmObjectTypePaymentCreateRequestVM ToVM(this CrmObjectTypePaymentCreateRequestDto dto)
        {
            return new CrmObjectTypePaymentCreateRequestVM().FillCrmObjectTypePaymentCreateRequestVM(dto);
        }
    }


}
