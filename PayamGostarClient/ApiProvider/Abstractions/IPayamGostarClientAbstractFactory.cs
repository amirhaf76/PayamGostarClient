namespace PayamGostarClient.ApiProvider.Abstractions
{
    public interface IPayamGostarClientAbstractFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();

        ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClientt();

        IPropertyDefinitionApiClient CreatePropertyDefinitionApiClient();

        IPropertyGroupApiClient CreatePropertyGroupApiClient();

        ICrmObjectTypeStageApiClient CreateCrmObjectTypeStageApiClient();

        // PropertyDefinitionApiClient
        IAutoNumberPropertyDefinitionApiClient CreateAutoNumberPropertyDefinitionApiClient();
        ICheckboxPropertyDefinitionApiClient CreateCheckboxPropertyDefinitionApiClient();
        IColorPropertyDefinitionApiClient CreateColorPropertyDefinitionApiClient();
        IIdentityPropertyDefinitionApiClient CreateCrmItemIdentityPropertyDefinitionApiClient();
        // ICrmItemPropertyDefinitionApiClient CreateCrmItemPropertyDefinitionApiClient();
        ICrmObjectMultiValuePropertyDefinitionApiClient CreateCrmObjectMultiValuePropertyDefinitionApiClient();
        ICrmObjectMultiValuePropertyDefinitionApiClient CreateCurrencyMultiValuePropertyDefinitionApiClient();
        ICurrencyPropertyDefinitionApiClient CreateCurrencyPropertyDefinitionApiClient();
        IDropDownListPropertyDefinitionApiClient CreateDropDownListPropertyDefinitionApiClient();
        IFileMultiValuePropertyDefinitionApiClient CreateFileMultiValuePropertyDefinitionApiClient();
        IFilePropertyDefinitionApiClient CreateFilePropertyDefinitionApiClient();
        IGpPropertyDefinitionApiClient CreateGpPropertyDefinitionApiClient();
        IGregorianDateMultiValuePropertyDefintionApiClient CreateGregorianDateMultiValuePropertyDefinitionApiClient();

        // IGregorianDateMultiValuePropertyDefintionApiClient miss
        IGregorianDatePropertyDefinitionApiClient CreateGregorianDatePropertyDefinitionApiClient();
        IHTMLPropertyDefinitionApiClient CreateHTMLPropertyDefinitionApiClient();
        IIdentityMultiValuePropertyDefinitionApiClient CreateIdentityMultiValuePropertyDefinitionApiClient();
        IImagePropertyDefinitionApiClient CreateImagePropertyDefinitionApiClient();
        ILabelPropertyDefinitionApiClient CreateLabelPropertyDefinitionApiClient();
        ILinkMultiValuePropertyDefinitionApiClient CreateLinkMultiValuePropertyDefinitionApiClient();
        ILinkPropertyDefinitionApiClient CreateLinkPropertyDefinitionApiClient();
        IMarketingCampaignPropertyDefinitionApiClient CreateMarketingCampaignPropertyDefinitionApiClient();
        INumberMultiValuePropertyDefinitionApiClient CreateNumberMultiValuePropertyDefinitionApiClient();
        INumberPropertyDefinitionApiClient CreateNumberPropertyDefinitionApiClient();
        IPersianDateMultiValuePropertyDefinitionApiClient CreatePersianDateMultiValuePropertyDefinitionApiClient();
        IPersianDatePropertyDefinitionApiClient CreatePersianDatePropertyDefinitionApiClient();
        IProductMultiValuePropertyDefinitionApiClient CreateProductMultiValuePropertyDefinitionApiClient();
        ISecurityItemMultiValuePropertyDefinitionApiClient CreateSecurityItemMultiValuePropertyDefinitionApiClient();
        ISecurityItemPropertyDefinitionApiClient CreateSecurityItemPropertyDefinitionApiClient();
        ITextMultiValuePropertyDefinitionApiClient CreateTextMultiValuePropertyDefinitionApiClient();
        ITextPropertyDefinitionApiClient CreateTextPropertyDefinitionApiClient();
        ITimePropertyDefinitionApiClient CreateTimePropertyDefinitionApiClient();
        IUserMultiValuePropertyDefinitionApiClient CreateUserMultiValuePropertyDefinitionApiClient();
        IUserPropertyDefinitionApiClient CreateUserPropertyDefinitionApiClient();


    }
}
