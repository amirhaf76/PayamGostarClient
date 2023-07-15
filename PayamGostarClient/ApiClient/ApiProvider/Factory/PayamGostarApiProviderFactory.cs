using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.ApiProvider.ClientModels;
using PayamGostarClient.ApiProvider;
using System;

namespace PayamGostarClient.ApiClient.ApiProvider.Factory
{
    public class PayamGostarApiProviderFactory : IPayamGostarApiProviderFactory
    {
        private readonly PayamGostarApiProviderConfig _config;

        public PayamGostarApiProviderFactory(PayamGostarApiProviderConfig config)
        {
            _config = config;
        }

        public ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient()
        {
            return CreateClient<ICrmObjectTypeApiClient, CrmObjectTypeApiClient>();
        }

        public ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClient()
        {
            return CreateClient<ICrmObjectTypeFormApiClient, CrmObjectTypeFormApiClient>();
        }

        public ICrmObjectTypeTicketApiClient CreateCrmObjectTypeTicketApiClient()
        {
            return CreateClient<ICrmObjectTypeTicketApiClient, CrmObjectTypeTicketApiClient>();
        }

        public ICrmObjectTypeIdentityApiClient CreateCrmObjectTypeIdentityApiClient()
        {
            return CreateClient<ICrmObjectTypeIdentityApiClient, CrmObjectTypeIdentityApiClient>();
        }

        public ICrmObjectTypeInvoiceApiClient CreateCrmObjectTypeInvoiceApiClient()
        {
            return CreateClient<ICrmObjectTypeInvoiceApiClient, CrmObjectTypeInvoiceApiClient>();
        }

        public ICrmObjectTypeQuoteApiClient CreateCrmObjectTypeQuoteApiClient()
        {
            return CreateClient<ICrmObjectTypeQuoteApiClient, CrmObjectTypeQuoteApiClient>();
        }

        public ICrmObjectTypeReturnPurchaseInvoiceApiClient CreateCrmObjectTypeReturnPurchaseInvoiceApiClient()
        {
            return CreateClient<ICrmObjectTypeReturnPurchaseInvoiceApiClient, CrmObjectTypeReturnPurchaseInvoiceApiClient>();
        }

        public ICrmObjectTypePurchaseInvoiceApiClient CreateCrmObjectTypePurchaseInvoiceApiClient()
        {
            return CreateClient<ICrmObjectTypePurchaseInvoiceApiClient, CrmObjectTypePurchaseInvoiceApiClient>();
        }

        public ICrmObjectTypePurchaseQuoteApiClient CreateCrmObjectTypePurchaseQuoteApiClient()
        {
            return CreateClient<ICrmObjectTypePurchaseQuoteApiClient, CrmObjectTypePurchaseQuoteApiClient>();
        }

        public ICrmObjectTypeReturnSaleInvoiceApiClient CreateCrmObjectTypeReturnSaleInvoiceApiClient()
        {
            return CreateClient<ICrmObjectTypeReturnSaleInvoiceApiClient, CrmObjectTypeReturnSaleInvoiceApiClient>();
        }

        public ICrmObjectTypeReceiptApiClient CreateCrmObjectTypeReceiptApiClient()
        {
            return CreateClient<ICrmObjectTypeReceiptApiClient, CrmObjectTypeReceiptApiClient>();
        }

        public ICrmObjectTypePaymentApiClient CreateCrmObjectTypePaymentApiClient()
        {
            return CreateClient<ICrmObjectTypePaymentApiClient, CrmObjectTypePaymentApiClient>();
        }



        public ICrmObjectTypeStageApiClient CreateCrmObjectTypeStageApiClient()
        {
            return CreateClient<ICrmObjectTypeStageApiClient, CrmObjectTypeStageApiClient>();
        }

        public IPropertyDefinitionApiClient CreatePropertyDefinitionApiClient()
        {
            return CreateClient<IPropertyDefinitionApiClient, PropertyDefinitionApiClient>();
        }

        public IPropertyGroupApiClient CreatePropertyGroupApiClient()
        {
            return CreateClient<IPropertyGroupApiClient, PropertyGroupApiClient>();
        }


        public ITextPropertyDefinitionApiClient CreateTextPropertyDefinitionApiClient()
        {
            return CreateClient<ITextPropertyDefinitionApiClient, TextPropertyDefinitionApiClient>();
        }

        public IFormPropertyDefinitionApiClient CreateFormPropertyDefinitionApiClient()
        {
            return CreateClient<IFormPropertyDefinitionApiClient, FormPropertyDefinitionApiClient>();
        }

        public IDropDownListPropertyDefinitionApiClient CreateDropDownListPropertyDefinitionApiClient()
        {
            return CreateClient<IDropDownListPropertyDefinitionApiClient, DropDownListPropertyDefinitionApiClient>();
        }

        public IDropDownListPropertyDefinitionValueApiClient CreateDropDownListPropertyDefinitionValueApiClient()
        {
            return CreateClient<IDropDownListPropertyDefinitionValueApiClient, DropDownListPropertyDefinitionValueApiClient>();
        }

        public IUserPropertyDefinitionApiClient CreateUserPropertyDefinitionApiClient()
        {
            return CreateClient<IUserPropertyDefinitionApiClient, UserPropertyDefinitionApiClient>();
        }

        public INumberPropertyDefinitionApiClient CreateNumberPropertyDefinitionApiClient()
        {
            return CreateClient<INumberPropertyDefinitionApiClient, NumberPropertyDefinitionApiClient>();
        }

        public IDepartmentPropertyDefinitionApiClient CreateDepartmentPropertyDefinitionApiClient()
        {
            return CreateClient<IDepartmentPropertyDefinitionApiClient, DepartmentPropertyDefinitionApiClient>();
        }

        public IPositionPropertyDefinitionApiClient CreatePositionPropertyDefinitionApiClient()
        {
            return CreateClient<IPositionPropertyDefinitionApiClient, PositionPropertyDefinitionApiClient>();
        }

        public IPersianDatePropertyDefinitionApiClient CreatePersianDatePropertyDefinitionApiClient()
        {
            return CreateClient<IPersianDatePropertyDefinitionApiClient, PersianDatePropertyDefinitionApiClient>();
        }

        public ILabelPropertyDefinitionApiClient CreateLabelPropertyDefinitionApiClient()
        {
            return CreateClient<ILabelPropertyDefinitionApiClient, LabelPropertyDefinitionApiClient>();
        }

        public ICrmObjectMultiValuePropertyDefinitionApiClient CreateCrmObjectMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ICrmObjectMultiValuePropertyDefinitionApiClient, CrmObjectMultiValuePropertyDefinitionApiClient>();
        }


        public ITimePropertyDefinitionApiClient CreateTimePropertyDefinitionApiClient()
        {
            return CreateClient<ITimePropertyDefinitionApiClient, TimePropertyDefinitionApiClient>();
        }

        public ICurrencyPropertyDefinitionApiClient CreateCurrencyPropertyDefinitionApiClient()
        {
            return CreateClient<ICurrencyPropertyDefinitionApiClient, CurrencyPropertyDefinitionApiClient>();
        }

        public IFilePropertyDefinitionApiClient CreateFilePropertyDefinitionApiClient()
        {
            return CreateClient<IFilePropertyDefinitionApiClient, FilePropertyDefinitionApiClient>();
        }

        public ICheckboxPropertyDefinitionApiClient CreateCheckboxPropertyDefinitionApiClient()
        {
            return CreateClient<ICheckboxPropertyDefinitionApiClient, CheckboxPropertyDefinitionApiClient>();
        }

        public IAppointmentPropertyDefinitionApiClient CreateAppointmentPropertyDefinitionApiClient()
        {
            return CreateClient<IAppointmentPropertyDefinitionApiClient, AppointmentPropertyDefinitionApiClient>();
        }

        public ISecurityItemPropertyDefinitionApiClient CreateSecurityItemPropertyDefinitionApiClient()
        {
            return CreateClient<ISecurityItemPropertyDefinitionApiClient, SecurityItemPropertyDefinitionApiClient>();
        }

        public IAutoNumberPropertyDefinitionApiClient CreateAutoNumberPropertyDefinitionApiClient()
        {
            return CreateClient<IAutoNumberPropertyDefinitionApiClient, AutoNumberPropertyDefinitionApiClient>();
        }

        public IGregorianDatePropertyDefinitionApiClient CreateGregorianDatePropertyDefinitionApiClient()
        {
            return CreateClient<IGregorianDatePropertyDefinitionApiClient, GregorianDatePropertyDefinitionApiClient>();
        }

        public IIdentityPropertyDefinitionApiClient CreateIdentityPropertyDefinitionApiClient()
        {
            return CreateClient<IIdentityPropertyDefinitionApiClient, IdentityPropertyDefinitionApiClient>();
        }

        public IGpPropertyDefinitionApiClient CreateGpPropertyDefinitionApiClient()
        {
            return CreateClient<IGpPropertyDefinitionApiClient, GpPropertyDefinitionApiClient>();
        }

        public IHTMLPropertyDefinitionApiClient CreateHTMLPropertyDefinitionApiClient()
        {
            return CreateClient<IHTMLPropertyDefinitionApiClient, HTMLPropertyDefinitionApiClient>();
        }

        public IImagePropertyDefinitionApiClient CreateImagePropertyDefinitionApiClient()
        {
            return CreateClient<IImagePropertyDefinitionApiClient, ImagePropertyDefinitionApiClient>();
        }

        public ILinkPropertyDefinitionApiClient CreateLinkPropertyDefinitionApiClient()
        {
            return CreateClient<ILinkPropertyDefinitionApiClient, LinkPropertyDefinitionApiClient>();
        }

        public IMarketingCampaignPropertyDefinitionApiClient CreateMarketingCampaignPropertyDefinitionApiClient()
        {
            return CreateClient<IMarketingCampaignPropertyDefinitionApiClient, MarketingCampaignPropertyDefinitionApiClient>();
        }


        public ICurrencyMultiValuePropertyDefintionApiClient CreateCurrencyMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ICurrencyMultiValuePropertyDefintionApiClient, CurrencyMultiValuePropertyDefintionApiClient>();
        }
        public IFileMultiValuePropertyDefinitionApiClient CreateFileMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IFileMultiValuePropertyDefinitionApiClient, FileMultiValuePropertyDefinitionApiClient>();
        }
        public IGregorianDateMultiValuePropertyDefintionApiClient CreateGregorianDateMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IGregorianDateMultiValuePropertyDefintionApiClient, GregorianDateMultiValuePropertyDefintionApiClient>();
        }
        public IIdentityMultiValuePropertyDefinitionApiClient CreateIdentityMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IIdentityMultiValuePropertyDefinitionApiClient, IdentityMultiValuePropertyDefinitionApiClient>();
        }
        public ILinkMultiValuePropertyDefinitionApiClient CreateLinkMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ILinkMultiValuePropertyDefinitionApiClient, LinkMultiValuePropertyDefinitionApiClient>();
        }
        public INumberMultiValuePropertyDefinitionApiClient CreateNumberMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<INumberMultiValuePropertyDefinitionApiClient, NumberMultiValuePropertyDefinitionApiClient>();
        }
        public IPersianDateMultiValuePropertyDefinitionApiClient CreatePersianDateMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IPersianDateMultiValuePropertyDefinitionApiClient, PersianDateMultiValuePropertyDefinitionApiClient>();
        }
        public IProductMultiValuePropertyDefinitionApiClient CreateProductMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IProductMultiValuePropertyDefinitionApiClient, ProductMultiValuePropertyDefinitionApiClient>();
        }
        public ISecurityItemMultiValuePropertyDefinitionApiClient CreateSecurityItemMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ISecurityItemMultiValuePropertyDefinitionApiClient, SecurityItemMultiValuePropertyDefinitionApiClient>();
        }
        public ITextMultiValuePropertyDefinitionApiClient CreateTextMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ITextMultiValuePropertyDefinitionApiClient, TextMultiValuePropertyDefinitionApiClient>();
        }
        public IUserMultiValuePropertyDefinitionApiClient CreateUserMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IUserMultiValuePropertyDefinitionApiClient, UserMultiValuePropertyDefinitionApiClient>();
        }





        public INumberingTemplateApiClient CreateNumberingTemplateApiClient()
        {
            return CreateClient<INumberingTemplateApiClient, NumberingTemplateApiClient>();
        }

        public ICategoryClient CreateCategoryClient()
        {
            return CreateClient<ICategoryClient, CategoryClient>();
        }


        private TAbstractClient CreateClient<TAbstractClient, TClient>()
            where TClient : PayamGostarBaseClient, TAbstractClient
        {
            return (TAbstractClient)Activator.CreateInstance(typeof(TClient), _config);
        }

    }
}
