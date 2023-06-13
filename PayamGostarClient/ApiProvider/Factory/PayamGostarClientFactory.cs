using PayamGostarClient.ApiProvider.Abstractions;
using System;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarClientFactory : IPayamGostarClientAbstractFactory
    {
        private readonly PayamGostarClientConfig _config;

        public PayamGostarClientFactory(PayamGostarClientConfig config)
        {
            _config = config;
        }

        public ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient()
        {
            return CreateClient<ICrmObjectTypeApiClient, CrmObjectTypeApiClient>();
        }

        public ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClientt()
        {
            return CreateClient<ICrmObjectTypeFormApiClient, CrmObjectTypeFormApiClient>();
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



        public ICheckboxPropertyDefinitionApiClient CreateCheckboxPropertyDefinitionApiClient()
        {
            return CreateClient<ICheckboxPropertyDefinitionApiClient, CheckboxPropertyDefinitionApiClient>();
        }

        public IColorPropertyDefinitionApiClient CreateColorPropertyDefinitionApiClient()
        {
            return CreateClient<IColorPropertyDefinitionApiClient, ColorPropertyDefinitionApiClient>();
        }

        public IIdentityPropertyDefinitionApiClient CreateCrmItemIdentityPropertyDefinitionApiClient()
        {
            return CreateClient<IIdentityPropertyDefinitionApiClient, IdentityPropertyDefinitionApiClient>();
        }

        public ICrmObjectMultiValuePropertyDefinitionApiClient CreateCrmObjectMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ICrmObjectMultiValuePropertyDefinitionApiClient, CrmObjectMultiValuePropertyDefinitionApiClient>();
        }

        public ICrmObjectMultiValuePropertyDefinitionApiClient CreateCurrencyMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ICrmObjectMultiValuePropertyDefinitionApiClient, CrmObjectMultiValuePropertyDefinitionApiClient>();
        }

        public ICurrencyPropertyDefinitionApiClient CreateCurrencyPropertyDefinitionApiClient()
        {
            return CreateClient<ICurrencyPropertyDefinitionApiClient, CurrencyPropertyDefinitionApiClient>();
        }

        public IDropDownListPropertyDefinitionApiClient CreateDropDownListPropertyDefinitionApiClient()
        {
            return CreateClient<IDropDownListPropertyDefinitionApiClient, DropDownListPropertyDefinitionApiClient>();
        }

        public IFileMultiValuePropertyDefinitionApiClient CreateFileMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IFileMultiValuePropertyDefinitionApiClient, FileMultiValuePropertyDefinitionApiClient>();
        }

        public IFilePropertyDefinitionApiClient CreateFilePropertyDefinitionApiClient()
        {
            return CreateClient<IFilePropertyDefinitionApiClient, FilePropertyDefinitionApiClient>();
        }

        public IGpPropertyDefinitionApiClient CreateGpPropertyDefinitionApiClient()
        {
            return CreateClient<IGpPropertyDefinitionApiClient, GpPropertyDefinitionApiClient>();
        }

        public IGregorianDateMultiValuePropertyDefintionApiClient CreateGregorianDateMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IGregorianDateMultiValuePropertyDefintionApiClient, GregorianDateMultiValuePropertyDefintionApiClient>();
        }

        public IGregorianDatePropertyDefinitionApiClient CreateGregorianDatePropertyDefinitionApiClient()
        {
            return CreateClient<IGregorianDatePropertyDefinitionApiClient, GregorianDatePropertyDefinitionApiClient>();
        }

        public IHTMLPropertyDefinitionApiClient CreateHTMLPropertyDefinitionApiClient()
        {
            return CreateClient<IHTMLPropertyDefinitionApiClient, HTMLPropertyDefinitionApiClient>();
        }

        public IIdentityMultiValuePropertyDefinitionApiClient CreateIdentityMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IIdentityMultiValuePropertyDefinitionApiClient, IdentityMultiValuePropertyDefinitionApiClient>();
        }

        public IImagePropertyDefinitionApiClient CreateImagePropertyDefinitionApiClient()
        {
            return CreateClient<IImagePropertyDefinitionApiClient, ImagePropertyDefinitionApiClient>();
        }

        public ILabelPropertyDefinitionApiClient CreateLabelPropertyDefinitionApiClient()
        {
            return CreateClient<ILabelPropertyDefinitionApiClient, LabelPropertyDefinitionApiClient>();
        }

        public ILinkMultiValuePropertyDefinitionApiClient CreateLinkMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ILinkMultiValuePropertyDefinitionApiClient, LinkMultiValuePropertyDefinitionApiClient>();
        }

        public ILinkPropertyDefinitionApiClient CreateLinkPropertyDefinitionApiClient()
        {
            return CreateClient<ILinkPropertyDefinitionApiClient, LinkPropertyDefinitionApiClient>();
        }

        public IMarketingCampaignPropertyDefinitionApiClient CreateMarketingCampaignPropertyDefinitionApiClient()
        {
            return CreateClient<IMarketingCampaignPropertyDefinitionApiClient, MarketingCampaignPropertyDefinitionApiClient>();
        }

        public INumberMultiValuePropertyDefinitionApiClient CreateNumberMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<INumberMultiValuePropertyDefinitionApiClient, NumberMultiValuePropertyDefinitionApiClient>();
        }

        public INumberPropertyDefinitionApiClient CreateNumberPropertyDefinitionApiClient()
        {
            return CreateClient<INumberPropertyDefinitionApiClient, NumberPropertyDefinitionApiClient>();
        }

        public IPersianDateMultiValuePropertyDefinitionApiClient CreatePersianDateMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IPersianDateMultiValuePropertyDefinitionApiClient, PersianDateMultiValuePropertyDefinitionApiClient>();
        }

        public IPersianDatePropertyDefinitionApiClient CreatePersianDatePropertyDefinitionApiClient()
        {
            return CreateClient<IPersianDatePropertyDefinitionApiClient, PersianDatePropertyDefinitionApiClient>();
        }

        public IProductMultiValuePropertyDefinitionApiClient CreateProductMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IProductMultiValuePropertyDefinitionApiClient, ProductMultiValuePropertyDefinitionApiClient>();
        }

        public ISecurityItemMultiValuePropertyDefinitionApiClient CreateSecurityItemMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ISecurityItemMultiValuePropertyDefinitionApiClient, SecurityItemMultiValuePropertyDefinitionApiClient>();
        }

        public ISecurityItemPropertyDefinitionApiClient CreateSecurityItemPropertyDefinitionApiClient()
        {
            return CreateClient<ISecurityItemPropertyDefinitionApiClient, SecurityItemPropertyDefinitionApiClient>();
        }

        public ITextMultiValuePropertyDefinitionApiClient CreateTextMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<ITextMultiValuePropertyDefinitionApiClient, TextMultiValuePropertyDefinitionApiClient>();
        }

        public ITextPropertyDefinitionApiClient CreateTextPropertyDefinitionApiClient()
        {
            return CreateClient<ITextPropertyDefinitionApiClient, TextPropertyDefinitionApiClient>();
        }

        public ITimePropertyDefinitionApiClient CreateTimePropertyDefinitionApiClient()
        {
            return CreateClient<ITimePropertyDefinitionApiClient, TimePropertyDefinitionApiClient>();
        }

        public IUserMultiValuePropertyDefinitionApiClient CreateUserMultiValuePropertyDefinitionApiClient()
        {
            return CreateClient<IUserMultiValuePropertyDefinitionApiClient, UserMultiValuePropertyDefinitionApiClient>();
        }

        public IUserPropertyDefinitionApiClient CreateUserPropertyDefinitionApiClient()
        {
            return CreateClient<IUserPropertyDefinitionApiClient, UserPropertyDefinitionApiClient>();
        }


        private TAbstractClient CreateClient<TAbstractClient, TClient>()
            where TClient : TAbstractClient
        {
            return (TAbstractClient)Activator.CreateInstance(typeof(TClient), _config);
        }

        public IAutoNumberPropertyDefinitionApiClient CreateAutoNumberPropertyDefinitionApiClient()
        {
            return CreateClient<IAutoNumberPropertyDefinitionApiClient, AutoNumberPropertyDefinitionApiClient>();
        }
    }
}
