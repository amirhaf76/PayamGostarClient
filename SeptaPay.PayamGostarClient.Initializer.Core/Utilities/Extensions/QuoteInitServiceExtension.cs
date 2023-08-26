using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
