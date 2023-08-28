using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeReceiptApiClientExtension
    {
        public static CrmObjectTypeReceiptCreateRequestVM ToVM(this CrmObjectTypeReceiptCreateRequestDto dto)
        {
            return new CrmObjectTypeReceiptCreateRequestVM().FillCrmObjectTypePaymentCreateRequestVM(dto);
        }
    }


}
