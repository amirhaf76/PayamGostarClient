using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeQuoteApiClientExtension
    {
        public static CrmObjectTypeQuoteCreateRequestVM ToVM(this CrmObjectTypeQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypeQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
