using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.ExtendedPropertyCreation;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies;
using PayamGostarClient.ApiClient.Exceptions;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Factory
{
    internal class ExtendedPropertyCreationFactory : IExtendedPropertyCreationFactory
    {
        private readonly IPayamGostarApiProviderFactory _clientFactory;

        public ExtendedPropertyCreationFactory(IPayamGostarApiProviderFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public IExtendedPropertyCreation Create(BaseExtendedPropertyDto baseProperty)
        {
            switch (baseProperty.Type)
            {
                case Gp_ExtendedPropertyType.Text:
                    return CreateExtendedPropertyCreation<TextExtendedPropertyCreation, TextExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Form:
                    return CreateExtendedPropertyCreation<FormExtendedPropertyCreation, FormExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.DropDownList:
                    return CreateExtendedPropertyCreation<DropDownListExtendedPropertyCreation, DropDownListExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.User:
                    return CreateExtendedPropertyCreation<UserExtendedPropertyCreation, UserExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Number:
                    return CreateExtendedPropertyCreation<NumberExtendedPropertyCreation, NumberExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Department:
                    return CreateExtendedPropertyCreation<DepartmentExtendedPropertyCreation, DepartmentExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Position:
                    return CreateExtendedPropertyCreation<PositionExtendedPropertyCreation, PositionExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Date:
                    return CreateExtendedPropertyCreation<PersianDateExtendedPropertyCreation, PersianDateExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Label:
                    return CreateExtendedPropertyCreation<LabelExtendedPropertyCreation, LabelExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return CreateExtendedPropertyCreation<CrmObjectMultiValueExtendedPropertyCreation, CrmObjectMultiValueExtendedPropertyCreationDto>(baseProperty);


                case Gp_ExtendedPropertyType.Time:
                    return CreateExtendedPropertyCreation<TimeExtendedPropertyCreation, TimeExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Currency:
                    return CreateExtendedPropertyCreation<CurrencyExtendedPropertyCreation, CurrencyExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.File:
                    return CreateExtendedPropertyCreation<FileExtendedPropertyCreation, FileExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Checkbox:
                    return CreateExtendedPropertyCreation<CheckboxExtendedPropertyCreation, CheckboxExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Appointment:
                    return CreateExtendedPropertyCreation<AppointmentExtendedPropertyCreation, CrmItemExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.SecurityItem:
                    return CreateExtendedPropertyCreation<SecurityItemExtendedPropertyCreation, SecurityItemExtendedPropertyCreationDto>(baseProperty);

                default:
                    throw new ExtendedPropertyTypeNotFoundException();
            }
        }


        private IExtendedPropertyCreation CreateExtendedPropertyCreation<TService, TInputDto>(BaseExtendedPropertyDto baseExtended)
            where TService : BaseExtendedPropertyCreation<TInputDto>, IExtendedPropertyCreation
            where TInputDto : BaseExtendedPropertyDto
        {
            return (IExtendedPropertyCreation)Activator.CreateInstance(typeof(TService), (TInputDto)baseExtended, _clientFactory);
        }


        private abstract class BaseExtendedPropertyCreation<T> : IExtendedPropertyCreation where T : BaseExtendedPropertyDto
        {
            protected T Property { get; }
            protected IPayamGostarApiProviderFactory ClientFactory { get; }

            public BaseExtendedPropertyCreation(T property, IPayamGostarApiProviderFactory clientFactory)
            {
                Property = property;
                ClientFactory = clientFactory;
            }


            public abstract Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync();

            public async Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync()
            {
                var propertyCreationResult = await CreatePropertyCreationActionAsync().ConfigureAwait(false);

                return propertyCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
        }


        private class TextExtendedPropertyCreation : BaseExtendedPropertyCreation<TextExtendedPropertyCreationDto>
        {
            public TextExtendedPropertyCreation(TextExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateTextPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2TextpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
            }
        }
        private class FormExtendedPropertyCreation : BaseExtendedPropertyCreation<FormExtendedPropertyCreationDto>
        {
            public FormExtendedPropertyCreation(FormExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateFormPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2FormpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
            }
        }
        private class DropDownListExtendedPropertyCreation : BaseExtendedPropertyCreation<DropDownListExtendedPropertyCreationDto>
        {
            public DropDownListExtendedPropertyCreation(DropDownListExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateDropDownListPropertyDefinitionApiClient();
                    var clientValueApi = ClientFactory.CreateDropDownListPropertyDefinitionValueApiClient();

                    var propertyCreationResult = await clientApi.PostApiV2DropdownlistpropertydefinitionCreateAsync(Property.ToVM());

                    foreach (var value in Property.Values)
                    {
                        // Todo: er
                        value.PropertyDefinitionId = propertyCreationResult.Result.Id;

                        await clientValueApi.PostApiV2DropDownListPropertyDefinitionValueCreateAsync(value.ToVM());
                    }

                    return propertyCreationResult;
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }


            }
        }
        private class UserExtendedPropertyCreation : BaseExtendedPropertyCreation<UserExtendedPropertyCreationDto>
        {
            public UserExtendedPropertyCreation(UserExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateUserPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2UserpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }

            }
        }
        private class NumberExtendedPropertyCreation : BaseExtendedPropertyCreation<NumberExtendedPropertyCreationDto>
        {
            public NumberExtendedPropertyCreation(NumberExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateNumberPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2NumberpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }

            }
        }
        private class DepartmentExtendedPropertyCreation : BaseExtendedPropertyCreation<DepartmentExtendedPropertyCreationDto>
        {
            public DepartmentExtendedPropertyCreation(DepartmentExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateDepartmentPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2DepartmentpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }

            }
        }
        private class PositionExtendedPropertyCreation : BaseExtendedPropertyCreation<PositionExtendedPropertyCreationDto>
        {
            public PositionExtendedPropertyCreation(PositionExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreatePositionPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2PositionpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }

            }
        }
        private class PersianDateExtendedPropertyCreation : BaseExtendedPropertyCreation<PersianDateExtendedPropertyCreationDto>
        {
            public PersianDateExtendedPropertyCreation(PersianDateExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreatePersianDatePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2PersiandatepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
            }
        }
        private class LabelExtendedPropertyCreation : BaseExtendedPropertyCreation<LabelExtendedPropertyCreationDto>
        {
            public LabelExtendedPropertyCreation(LabelExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateLabelPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2LabelpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
            }
        }
        private class CrmObjectMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmObjectMultiValueExtendedPropertyCreationDto>
        {
            public CrmObjectMultiValueExtendedPropertyCreation(CrmObjectMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateCrmObjectMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2CrmObjectmultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
            }
        }
        private class TimeExtendedPropertyCreation : BaseExtendedPropertyCreation<TimeExtendedPropertyCreationDto>
        {
            public TimeExtendedPropertyCreation(TimeExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateTimePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2TimepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
                throw new NotImplementedException();
            }
        }
        private class CurrencyExtendedPropertyCreation : BaseExtendedPropertyCreation<CurrencyExtendedPropertyCreationDto>
        {
            public CurrencyExtendedPropertyCreation(CurrencyExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateCurrencyPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2CurrencypropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }

                throw new NotImplementedException();
            }
        }
        private class FileExtendedPropertyCreation : BaseExtendedPropertyCreation<FileExtendedPropertyCreationDto>
        {
            public FileExtendedPropertyCreation(FileExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateFilePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2FilepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
                throw new NotImplementedException();
            }
        }
        private class CheckboxExtendedPropertyCreation : BaseExtendedPropertyCreation<CheckboxExtendedPropertyCreationDto>
        {
            public CheckboxExtendedPropertyCreation(CheckboxExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateCheckboxPropertyDefinitionApiClient();

                    return clientApi.PostApiV2CheckboxpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
                throw new NotImplementedException();
            }
        }
        private class AppointmentExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmItemExtendedPropertyCreationDto>
        {
            public AppointmentExtendedPropertyCreation(CrmItemExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateAppointmentPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2AppointmentpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
                throw new NotImplementedException();
            }
        }
        private class SecurityItemExtendedPropertyCreation : BaseExtendedPropertyCreation<SecurityItemExtendedPropertyCreationDto>
        {
            public SecurityItemExtendedPropertyCreation(SecurityItemExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateSecurityItemPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2SecurityitempropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(Property), e);
                }
                throw new NotImplementedException();
            }
        }

    }

}
