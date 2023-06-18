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
                // return new AutoNumerExtendedPropertyCreation((AutoNumerExtendedPropertyCreationDto)baseProperty, _clientFactory);

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
    }

}
