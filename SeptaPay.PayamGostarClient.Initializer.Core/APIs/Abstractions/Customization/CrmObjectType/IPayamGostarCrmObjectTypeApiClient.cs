using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeApiClient
    {
        IPayamGostarCrmObjectTypeFormApiClient FormApi { get; }
        IPayamGostarCrmObjectTypeStageApiClient StageApi { get; }
        IPayamGostarCrmObjectTypeTicketApiClient TicketApi { get; }
        IPayamGostarCrmObjectTypeIdentityApiClient IdentityApi { get; }

        IPayamGostarCrmObjectTypeInvoiceApiClient InvoiceApi { get; }
        IPayamGostarCrmObjectTypePurchaseInvoiceApiClient PurchaseInvoiceApi { get; }

        IPayamGostarCrmObjectTypeReturnInvoiceApiClient ReturnInvoiceApi { get; }
        IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient ReturnPurchaseInvoiceApi { get; }

        IPayamGostarCrmObjectTypeQuoteApiClient QuoteApi { get; }
        IPayamGostarCrmObjectTypePurchaseQuoteApiClient PurchaseQuoteApi { get; }

        IPayamGostarCrmObjectTypeReceiptApiClient ReceiptApi { get; }
        IPayamGostarCrmObjectTypePaymentApiClient PaymentApi { get; }

        Task<IEnumerable<CrmObjectTypeSearchResultDto>> SearchAsync(CrmObjectTypeSearchRequestDto request);
    }
}