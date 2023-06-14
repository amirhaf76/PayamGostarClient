namespace PayamGostarClient.ApiProvider.Abstractions
{
    public interface IPayamGostarClientAbstractFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();

        ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClientt();

        IPropertyDefinitionApiClient CreatePropertyDefinitionApiClient();


        IPropertyGroupApiClient CreatePropertyGroupApiClient();

        ICrmObjectTypeStageApiClient CreateCrmObjectTypeStageApiClient();


        ITextPropertyDefinitionApiClient CreateTextPropertyDefinitionApiClient();
        IFormPropertyDefinitionApiClient CreateFormPropertyDefinitionApiClient();
        IDropDownListPropertyDefinitionApiClient CreateDropDownListPropertyDefinitionApiClient();
        IDropDownListPropertyDefinitionValueApiClient CreateDropDownListPropertyDefinitionValueApiClient();
        IUserPropertyDefinitionApiClient CreateUserPropertyDefinitionApiClient();
        INumberPropertyDefinitionApiClient CreateNumberPropertyDefinitionApiClient();
        IDepartmentPropertyDefinitionApiClient CreateDepartmentPropertyDefinitionApiClient();
        IPositionPropertyDefinitionApiClient CreatePositionPropertyDefinitionApiClient();
        IPersianDatePropertyDefinitionApiClient CreatePersianDatePropertyDefinitionApiClient();
        ILabelPropertyDefinitionApiClient CreateLabelPropertyDefinitionApiClient();
        ICrmObjectMultiValuePropertyDefinitionApiClient CreateCrmObjectMultiValuePropertyDefinitionApiClient();

    }
}
