﻿using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiProvider.ClientModels;
using System;

namespace PayamGostarClient.ApiProvider.Factory
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



        private TAbstractClient CreateClient<TAbstractClient, TClient>()
            where TClient : PayamGostarBaseClient, TAbstractClient
        {
            return (TAbstractClient)Activator.CreateInstance(typeof(TClient), _config);
        }

    }
}