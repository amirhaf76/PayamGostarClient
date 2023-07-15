using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.ApiProvider.Abstractions
{
    public interface IPayamGostarApiProviderFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();


        ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClient();

        ICrmObjectTypeTicketApiClient CreateCrmObjectTypeTicketApiClient();

        ICrmObjectTypeIdentityApiClient CreateCrmObjectTypeIdentityApiClient();

        ICrmObjectTypeInvoiceApiClient CreateCrmObjectTypeInvoiceApiClient();

        ICrmObjectTypeQuoteApiClient CreateCrmObjectTypeQuoteApiClient();

        ICrmObjectTypePurchaseInvoiceApiClient CreateCrmObjectTypePurchaseInvoiceApiClient();

        ICrmObjectTypePurchaseQuoteApiClient CreateCrmObjectTypePurchaseQuoteApiClient();

        ICrmObjectTypeReturnPurchaseInvoiceApiClient CreateCrmObjectTypeReturnPurchaseInvoiceApiClient();

        ICrmObjectTypeReturnSaleInvoiceApiClient CreateCrmObjectTypeReturnSaleInvoiceApiClient();

        ICrmObjectTypeReceiptApiClient CreateCrmObjectTypeReceiptApiClient();

        ICrmObjectTypePaymentApiClient CreateCrmObjectTypePaymentApiClient();


        IPropertyDefinitionApiClient CreatePropertyDefinitionApiClient();

        IPropertyGroupApiClient CreatePropertyGroupApiClient();

        ICrmObjectTypeStageApiClient CreateCrmObjectTypeStageApiClient();

        INumberingTemplateApiClient CreateNumberingTemplateApiClient();

        ICategoryClient CreateCategoryClient();


        IAppointmentPropertyDefinitionApiClient CreateAppointmentPropertyDefinitionApiClient();
        IAutoNumberPropertyDefinitionApiClient CreateAutoNumberPropertyDefinitionApiClient();
        ICheckboxPropertyDefinitionApiClient CreateCheckboxPropertyDefinitionApiClient();
        ICurrencyPropertyDefinitionApiClient CreateCurrencyPropertyDefinitionApiClient();
        IDepartmentPropertyDefinitionApiClient CreateDepartmentPropertyDefinitionApiClient();
        IDropDownListPropertyDefinitionApiClient CreateDropDownListPropertyDefinitionApiClient();
        IDropDownListPropertyDefinitionValueApiClient CreateDropDownListPropertyDefinitionValueApiClient();
        IFilePropertyDefinitionApiClient CreateFilePropertyDefinitionApiClient();
        IFormPropertyDefinitionApiClient CreateFormPropertyDefinitionApiClient();
        IGpPropertyDefinitionApiClient CreateGpPropertyDefinitionApiClient();
        IGregorianDatePropertyDefinitionApiClient CreateGregorianDatePropertyDefinitionApiClient();
        IHTMLPropertyDefinitionApiClient CreateHTMLPropertyDefinitionApiClient();
        IIdentityPropertyDefinitionApiClient CreateIdentityPropertyDefinitionApiClient();
        IImagePropertyDefinitionApiClient CreateImagePropertyDefinitionApiClient();
        ILabelPropertyDefinitionApiClient CreateLabelPropertyDefinitionApiClient();
        ILinkPropertyDefinitionApiClient CreateLinkPropertyDefinitionApiClient();
        IMarketingCampaignPropertyDefinitionApiClient CreateMarketingCampaignPropertyDefinitionApiClient();
        INumberPropertyDefinitionApiClient CreateNumberPropertyDefinitionApiClient();
        IPersianDatePropertyDefinitionApiClient CreatePersianDatePropertyDefinitionApiClient();
        IPositionPropertyDefinitionApiClient CreatePositionPropertyDefinitionApiClient();
        ISecurityItemPropertyDefinitionApiClient CreateSecurityItemPropertyDefinitionApiClient();
        ITextPropertyDefinitionApiClient CreateTextPropertyDefinitionApiClient();
        ITimePropertyDefinitionApiClient CreateTimePropertyDefinitionApiClient();
        IUserPropertyDefinitionApiClient CreateUserPropertyDefinitionApiClient();

        ICrmObjectMultiValuePropertyDefinitionApiClient CreateCrmObjectMultiValuePropertyDefinitionApiClient();
        ICurrencyMultiValuePropertyDefintionApiClient CreateCurrencyMultiValuePropertyDefinitionApiClient();
        IFileMultiValuePropertyDefinitionApiClient CreateFileMultiValuePropertyDefinitionApiClient();
        IGregorianDateMultiValuePropertyDefintionApiClient CreateGregorianDateMultiValuePropertyDefinitionApiClient();
        IIdentityMultiValuePropertyDefinitionApiClient CreateIdentityMultiValuePropertyDefinitionApiClient();
        ILinkMultiValuePropertyDefinitionApiClient CreateLinkMultiValuePropertyDefinitionApiClient();
        INumberMultiValuePropertyDefinitionApiClient CreateNumberMultiValuePropertyDefinitionApiClient();
        IPersianDateMultiValuePropertyDefinitionApiClient CreatePersianDateMultiValuePropertyDefinitionApiClient();
        IProductMultiValuePropertyDefinitionApiClient CreateProductMultiValuePropertyDefinitionApiClient();
        ISecurityItemMultiValuePropertyDefinitionApiClient CreateSecurityItemMultiValuePropertyDefinitionApiClient();
        ITextMultiValuePropertyDefinitionApiClient CreateTextMultiValuePropertyDefinitionApiClient();
        IUserMultiValuePropertyDefinitionApiClient CreateUserMultiValuePropertyDefinitionApiClient();
    }
}
