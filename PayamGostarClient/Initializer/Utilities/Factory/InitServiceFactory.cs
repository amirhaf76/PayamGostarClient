using PayamGostarClient.ApiClient;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Abstractions.InitServices;
using PayamGostarClient.Initializer.Abstractions.Utilities.Factories;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Enums;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Services;
using PayamGostarClient.Initializer.Utilities.Extensions;

namespace PayamGostarClient.Initializer.Utilities.Factory
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private readonly IPayamGostarApiClient _payamGostarApiClient;

        public InitServiceFactory(InitServiceFactoryConfig config)
        {
            _payamGostarApiClient = new PayamGostarApiClient(config.ClientService);

            BaseInitServiceExtension.LanguageCulture = config.ClientService.LanguageCulture;
        }

        private IInitService Create(BaseCRMModel model)
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService((CrmFormModel)model, _payamGostarApiClient);

                case Gp_CrmObjectType.Ticket:
                    return new TicketInitService((CrmTicketModel)model, _payamGostarApiClient);

                case Gp_CrmObjectType.Identity:
                    return new IdentityService((CrmIdentityModel)model, _payamGostarApiClient);

                case Gp_CrmObjectType.Invoice:
                    return new InvoiceInitService((CrmInvoiceModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.PurchaseInvoice:
                    return new PurchaseInvoiceInitService((CrmPurchaseInvoiceModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.ReturnPurchaseInvoice:
                    return new ReturnPurchaseInvoiceInitService((CrmReturnPurchaseInvoiceModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.ReturnSaleInvoice:
                    return new ReturnSaleInvoiceInitService((CrmReturnSaleInvoiceModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.Quote:
                    return new QuoteInitService((CrmQuoteModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.PurchaseQuote:
                    return new PurchaseQuoteInitService((CrmPurchaseQuoteModel)model, _payamGostarApiClient);

                case Gp_CrmObjectType.Payment:
                    return new PaymentInitService((CrmPaymentModel)model, _payamGostarApiClient);
                case Gp_CrmObjectType.Receipt:
                    return new ReceiptInitService((CrmReceiptModel)model, _payamGostarApiClient);

                default:
                    throw new InvalidGpCrmObjectTypeException($"CrmModel with '{model.Code}' code has unsupported model type! ModelType: '{model.Type}'.");
            }
        }

        public IInitService Create(ICustomizationCrmModel model)
        {
            switch (model.CustomizationCrmType)
            {
                case CustomizationCrmType.CrmObjectType:
                    return Create((BaseCRMModel)model);

                case CustomizationCrmType.NumberingTemplate:
                    return new NumberingTemplateInitService((NumberingTemplateModel)model, _payamGostarApiClient);

                case CustomizationCrmType.GeneralCrmObjectType:
                    return new CrmGeneralModelInitService((CrmGeneralModel)model, _payamGostarApiClient);

                default:
                    throw new InvalidCustomizationCrmTypeException($"There is no CustomizationCrmType like '{model.CustomizationCrmType}'");
            }
        }

    }


}
