﻿using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.ApiProvider.Abstractions
{
    public interface IPayamGostarApiProviderFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();

        ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClient();

        ICrmObjectTypeTicketApiClient CreateCrmObjectTypeTicketApiClient();

        ICrmObjectTypeIdentityApiClient CreateCrmObjectTypeIdentityApiClient();

        ICrmObjectTypeInvoiceApiClient CreateCrmObjectTypeInvoiceApiClient();


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


        ITimePropertyDefinitionApiClient CreateTimePropertyDefinitionApiClient();
        ICurrencyPropertyDefinitionApiClient CreateCurrencyPropertyDefinitionApiClient();
        IFilePropertyDefinitionApiClient CreateFilePropertyDefinitionApiClient();
        ICheckboxPropertyDefinitionApiClient CreateCheckboxPropertyDefinitionApiClient();
        IAppointmentPropertyDefinitionApiClient CreateAppointmentPropertyDefinitionApiClient();
        ISecurityItemPropertyDefinitionApiClient CreateSecurityItemPropertyDefinitionApiClient();

    }
}
