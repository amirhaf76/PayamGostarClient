using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class QuoteInitServiceExtension
    {
        internal static CrmObjectTypeQuoteCreateRequestDto ToDto(this CrmQuoteModel model)
        {
            return new CrmObjectTypeQuoteCreateRequestDto
            {
                CanMultipleCloneInvoice = model.CanMultipleCloneInvoice,

            }.FillCrmObjectTypeBaseInvoiceCreateRequestDto(model);
        }
    }
}
