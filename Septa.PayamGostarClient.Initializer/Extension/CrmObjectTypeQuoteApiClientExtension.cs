using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeQuoteApiClientExtension
    {
        public static CrmObjectTypeQuoteCreateRequestVM ToVM(this CrmObjectTypeQuoteCreateRequestDto dto)
        {
            return new CrmObjectTypeQuoteCreateRequestVM().FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }
    }
}
