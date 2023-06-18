using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiServices.Exceptions;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Factory
{
    internal class ExtendedPropertyCreationFactory : IExtendedPropertyCreationFactory
    {
        private readonly IPayamGostarClientAbstractFactory _clientFactory;

        public ExtendedPropertyCreationFactory(IPayamGostarClientAbstractFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IExtendedPropertyCreationService Create(BaseExtendedPropertyDto baseProperty)
        {
            switch (baseProperty.Type)
            {
                case Gp_ExtendedPropertyType.Text:
                    return CreateExtendedPropertyCreationService<TextExtendedPropertyCreation, TextExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Form:
                    return CreateExtendedPropertyCreationService<FormExtendedPropertyCreation, FormExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.DropDownList:
                    return CreateExtendedPropertyCreationService<DropDownListExtendedPropertyCreation, DropDownListExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.User:
                    return CreateExtendedPropertyCreationService<UserExtendedPropertyCreation, UserExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Number:
                    return CreateExtendedPropertyCreationService<NumberExtendedPropertyCreation, NumberExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Department:
                    return CreateExtendedPropertyCreationService<DepartmentExtendedPropertyCreation, DepartmentExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Position:
                    return CreateExtendedPropertyCreationService<PositionExtendedPropertyCreation, PositionExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Date:
                    return CreateExtendedPropertyCreationService<PersianDateExtendedPropertyCreation, PersianDateExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Label:
                    return CreateExtendedPropertyCreationService<LabelExtendedPropertyCreation, LabelExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return CreateExtendedPropertyCreationService<CrmObjectMultiValueExtendedPropertyCreation, CrmObjectMultiValueExtendedPropertyCreationDto>(baseProperty);


                case Gp_ExtendedPropertyType.Time:
                    return CreateExtendedPropertyCreationService<TimeExtendedPropertyCreation, TimeExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Currency:
                    return CreateExtendedPropertyCreationService<CurrencyExtendedPropertyCreation, CurrencyExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.File:
                    return CreateExtendedPropertyCreationService<FileExtendedPropertyCreation, FileExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Checkbox:
                    return CreateExtendedPropertyCreationService<CheckboxExtendedPropertyCreation, CheckboxExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Appointment:
                    return CreateExtendedPropertyCreationService<AppointmentExtendedPropertyCreation, CrmItemExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.SecurityItem:
                    return CreateExtendedPropertyCreationService<SecurityItemExtendedPropertyCreation, SecurityItemExtendedPropertyCreationDto>(baseProperty);

                default:
                    throw new ExtendedPropertyTypeNotFoundException();
            }
        }

        private IExtendedPropertyCreationService CreateExtendedPropertyCreationService<TService, TInputDto>(BaseExtendedPropertyDto baseExtended)
            where TService : BaseExtendedPropertyCreation<TInputDto>, IExtendedPropertyCreationService
            where TInputDto : BaseExtendedPropertyDto
        {
            return (IExtendedPropertyCreationService)Activator.CreateInstance(typeof(TService), (TInputDto)baseExtended, _clientFactory);
        }

        private abstract class BaseExtendedPropertyCreation<T> : IExtendedPropertyCreationService where T : BaseExtendedPropertyDto
        {
            protected T Property { get; }
            protected IPayamGostarClientAbstractFactory ClientFactory { get; }

            public BaseExtendedPropertyCreation(T property, IPayamGostarClientAbstractFactory clientFactory)
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
            public TextExtendedPropertyCreation(TextExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
            }
        }
        private class FormExtendedPropertyCreation : BaseExtendedPropertyCreation<FormExtendedPropertyCreationDto>
        {
            public FormExtendedPropertyCreation(FormExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
            }
        }
        private class DropDownListExtendedPropertyCreation : BaseExtendedPropertyCreation<DropDownListExtendedPropertyCreationDto>
        {
            public DropDownListExtendedPropertyCreation(DropDownListExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }


            }
        }
        private class UserExtendedPropertyCreation : BaseExtendedPropertyCreation<UserExtendedPropertyCreationDto>
        {
            public UserExtendedPropertyCreation(UserExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }

            }
        }
        private class NumberExtendedPropertyCreation : BaseExtendedPropertyCreation<NumberExtendedPropertyCreationDto>
        {
            public NumberExtendedPropertyCreation(NumberExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }

            }
        }
        private class DepartmentExtendedPropertyCreation : BaseExtendedPropertyCreation<DepartmentExtendedPropertyCreationDto>
        {
            public DepartmentExtendedPropertyCreation(DepartmentExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }

            }
        }
        private class PositionExtendedPropertyCreation : BaseExtendedPropertyCreation<PositionExtendedPropertyCreationDto>
        {
            public PositionExtendedPropertyCreation(PositionExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }

            }
        }
        private class PersianDateExtendedPropertyCreation : BaseExtendedPropertyCreation<PersianDateExtendedPropertyCreationDto>
        {
            public PersianDateExtendedPropertyCreation(PersianDateExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
            }
        }
        private class LabelExtendedPropertyCreation : BaseExtendedPropertyCreation<LabelExtendedPropertyCreationDto>
        {
            public LabelExtendedPropertyCreation(LabelExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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

                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
            }
        }
        private class CrmObjectMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmObjectMultiValueExtendedPropertyCreationDto>
        {
            public CrmObjectMultiValueExtendedPropertyCreation(CrmObjectMultiValueExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
            }
        }


        private class TimeExtendedPropertyCreation : BaseExtendedPropertyCreation<TimeExtendedPropertyCreationDto>
        {
            public TimeExtendedPropertyCreation(TimeExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
                throw new NotImplementedException();
            }
        }
        private class CurrencyExtendedPropertyCreation : BaseExtendedPropertyCreation<CurrencyExtendedPropertyCreationDto>
        {
            public CurrencyExtendedPropertyCreation(CurrencyExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }

                throw new NotImplementedException();
            }
        }
        private class FileExtendedPropertyCreation : BaseExtendedPropertyCreation<FileExtendedPropertyCreationDto>
        {
            public FileExtendedPropertyCreation(FileExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
                throw new NotImplementedException();
            }
        }
        private class CheckboxExtendedPropertyCreation : BaseExtendedPropertyCreation<CheckboxExtendedPropertyCreationDto>
        {
            public CheckboxExtendedPropertyCreation(CheckboxExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
                throw new NotImplementedException();
            }
        }
        private class AppointmentExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmItemExtendedPropertyCreationDto>
        {
            public AppointmentExtendedPropertyCreation(CrmItemExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
                throw new NotImplementedException();
            }
        }
        private class SecurityItemExtendedPropertyCreation : BaseExtendedPropertyCreation<SecurityItemExtendedPropertyCreationDto>
        {
            public SecurityItemExtendedPropertyCreation(SecurityItemExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
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
                    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
                }
                throw new NotImplementedException();
            }
        }

    }

}
