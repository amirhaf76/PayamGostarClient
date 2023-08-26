using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.InitServices;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Factories;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.Exceptions;
using SeptaPay.PayamGostarClient.Initializer.Core.Services;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.AbstractFactories;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Factory
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private readonly IPayamGostarApiClient _payamGostarApiClient;
        private readonly IMatchingValidator _matchingValidator;

        public InitServiceFactory(IMatchingValidator matchingValidator, IPayamGostarApiClient payamGostarApiClient, string languageCulture = "fa-IR")
        {
            _matchingValidator = matchingValidator;
            _payamGostarApiClient = payamGostarApiClient;

            BaseInitServiceExtension.LanguageCulture = languageCulture;
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
                    return new SuperCrmModelInitService((SuperCrmModel)model, _payamGostarApiClient);

                case CustomizationCrmType.Category:
                    return new CategoryInitService((CategoryModel)model, _payamGostarApiClient);

                case CustomizationCrmType.ProductGroup:
                    return new ProductGroupInitService((ProductGroupModel)model, _payamGostarApiClient);

                default:
                    throw new InvalidCustomizationCrmTypeException($"There is no CustomizationCrmType like '{model.CustomizationCrmType}'");
            }
        }


        private IInitService Create(BaseCRMModel model)
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService((CrmFormModel)model, CreateBasicInitializationFactory());

                case Gp_CrmObjectType.Ticket:
                    return new TicketInitService((CrmTicketModel)model, CreateBasicInitializationFactory());


                case Gp_CrmObjectType.Identity:
                    return new IdentityService((CrmIdentityModel)model, CreateNumericalInitializationFactory());


                case Gp_CrmObjectType.Invoice:
                    return new InvoiceInitService((CrmInvoiceModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.PurchaseInvoice:
                    return new PurchaseInvoiceInitService((CrmPurchaseInvoiceModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.ReturnPurchaseInvoice:
                    return new ReturnPurchaseInvoiceInitService((CrmReturnPurchaseInvoiceModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.ReturnSaleInvoice:
                    return new ReturnSaleInvoiceInitService((CrmReturnSaleInvoiceModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.Quote:
                    return new QuoteInitService((CrmQuoteModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.PurchaseQuote:
                    return new PurchaseQuoteInitService((CrmPurchaseQuoteModel)model, CreateNumericalInitializationFactory());


                case Gp_CrmObjectType.Payment:
                    return new PaymentInitService((CrmPaymentModel)model, CreateNumericalInitializationFactory());

                case Gp_CrmObjectType.Receipt:
                    return new ReceiptInitService((CrmReceiptModel)model, CreateNumericalInitializationFactory());

                default:
                    throw new InvalidGpCrmObjectTypeException($"CrmModel with '{model.Code}' code has unsupported model type! ModelType: '{model.Type}'.");
            }
        }


        private NumericalInitServiceAbstractFactory CreateNumericalInitializationFactory()
        {
            return new NumericalInitServiceAbstractFactory(_payamGostarApiClient, _matchingValidator);
        }

        private InitServiceAbstractFactory CreateBasicInitializationFactory()
        {
            return new InitServiceAbstractFactory(_payamGostarApiClient, _matchingValidator);
        }

    }


}
