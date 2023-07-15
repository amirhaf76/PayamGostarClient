using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.ApiClient.Exceptions;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.ExtendedProperty.Factory
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

                case Gp_ExtendedPropertyType.AutoNumber:
                    return CreateExtendedPropertyCreation<AutoNumberExtendedPropertyCreation, AutoNumberExtendedPropertyCreationDto>(baseProperty);


                case Gp_ExtendedPropertyType.Identity:
                    return CreateExtendedPropertyCreation<CrmItemIdentityExtendedPropertyCreation, CrmItemIdentityExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.GeneralProperty:
                    return CreateExtendedPropertyCreation<GpExtendedPropertyCreation, GpExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.GregorianDate:
                    return CreateExtendedPropertyCreation<GregorianDateExtendedPropertyCreation, GregorianDateExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Html:
                    return CreateExtendedPropertyCreation<HTMLExtendedPropertyCreation, HTMLExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Image:
                    return CreateExtendedPropertyCreation<ImageExtendedPropertyCreation, ImageExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.Link:
                    return CreateExtendedPropertyCreation<LinkExtendedPropertyCreation, LinkExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.MarketingCampaign:
                    return CreateExtendedPropertyCreation<MarketingCampaignExtendedPropertyCreation, MarketingCampaignExtendedPropertyCreationDto>(baseProperty);


                case Gp_ExtendedPropertyType.CurrencyMultiValue:
                    return CreateExtendedPropertyCreation<CurrencyMultiValueExtendedPropertyCreation, CurrencyMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.FileMultiValue:
                    return CreateExtendedPropertyCreation<FileMultiValueExtendedPropertyCreation, FileMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.GregorianDateMultiValue:
                    return CreateExtendedPropertyCreation<GregorianDateMultiValueExtendedPropertyCreation, GregorianDateMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.IdentityMultiValue:
                    return CreateExtendedPropertyCreation<IdentityMultiValueExtendedPropertyCreation, IdentityMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.LinkMultiValue:
                    return CreateExtendedPropertyCreation<LinkMultiValueExtendedPropertyCreation, LinkMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.NumberMultiValue:
                    return CreateExtendedPropertyCreation<NumberMultiValueExtendedPropertyCreation, NumberMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.PersianDateMultiValue:
                    return CreateExtendedPropertyCreation<PersianDateMultiValueExtendedPropertyCreation, PersianDateMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.ProductList:
                    return CreateExtendedPropertyCreation<ProductMultiValueExtendedPropertyCreation, ProductMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.SecurityItemMultiValue:
                    return CreateExtendedPropertyCreation<SecurityItemMultiValueExtendedPropertyCreation, SecurityItemMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.TextMultiValue:
                    return CreateExtendedPropertyCreation<TextMultiValueExtendedPropertyCreation, TextMultiValueExtendedPropertyCreationDto>(baseProperty);

                case Gp_ExtendedPropertyType.UserMultiValue:
                    return CreateExtendedPropertyCreation<UserMultiValueExtendedPropertyCreation,  UserMultiValueExtendedPropertyCreationDto>(baseProperty);

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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
                throw new NotImplementedException();
            }
        }
        private class AutoNumberExtendedPropertyCreation : BaseExtendedPropertyCreation<AutoNumberExtendedPropertyCreationDto>
        {
            public AutoNumberExtendedPropertyCreation(AutoNumberExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateAutoNumberPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2AutonumberpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }

                throw new NotImplementedException();
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }


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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
                throw new NotImplementedException();
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }

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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
                throw new NotImplementedException();
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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
                throw new NotImplementedException();
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

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
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
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }

        private class CrmItemIdentityExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmItemIdentityExtendedPropertyCreationDto>
        {
            public CrmItemIdentityExtendedPropertyCreation(CrmItemIdentityExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateIdentityPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2IdentitypropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class GpExtendedPropertyCreation : BaseExtendedPropertyCreation<GpExtendedPropertyCreationDto>
        {
            public GpExtendedPropertyCreation(GpExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateGpPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2GppropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
                throw new NotImplementedException();
            }
        }
        private class GregorianDateExtendedPropertyCreation : BaseExtendedPropertyCreation<GregorianDateExtendedPropertyCreationDto>
        {
            public GregorianDateExtendedPropertyCreation(GregorianDateExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateGregorianDatePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2GregoriandatepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class HTMLExtendedPropertyCreation : BaseExtendedPropertyCreation<HTMLExtendedPropertyCreationDto>
        {
            public HTMLExtendedPropertyCreation(HTMLExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateHTMLPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2HtmlpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class ImageExtendedPropertyCreation : BaseExtendedPropertyCreation<ImageExtendedPropertyCreationDto>
        {
            public ImageExtendedPropertyCreation(ImageExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateImagePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2ImagepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class LinkExtendedPropertyCreation : BaseExtendedPropertyCreation<LinkExtendedPropertyCreationDto>
        {
            public LinkExtendedPropertyCreation(LinkExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateLinkPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2LinkpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class MarketingCampaignExtendedPropertyCreation : BaseExtendedPropertyCreation<MarketingCampaignExtendedPropertyCreationDto>
        {
            public MarketingCampaignExtendedPropertyCreation(MarketingCampaignExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateMarketingCampaignPropertyDefinitionApiClient();

                    return await clientApi.PostApiV2MarketingcampaignpropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {

                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }

        private class CurrencyMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<CurrencyMultiValueExtendedPropertyCreationDto>
        {
            public CurrencyMultiValueExtendedPropertyCreation(CurrencyMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateCurrencyMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2CurrencymultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class FileMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<FileMultiValueExtendedPropertyCreationDto>
        {
            public FileMultiValueExtendedPropertyCreation(FileMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateFileMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2FilemultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class GregorianDateMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<GregorianDateMultiValueExtendedPropertyCreationDto>
        {
            public GregorianDateMultiValueExtendedPropertyCreation(GregorianDateMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateGregorianDateMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2GregoriandatemultivaluepropertydefintionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class IdentityMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<IdentityMultiValueExtendedPropertyCreationDto>
        {
            public IdentityMultiValueExtendedPropertyCreation(IdentityMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateIdentityMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2IdentitymultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class LinkMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<LinkMultiValueExtendedPropertyCreationDto>
        {
            public LinkMultiValueExtendedPropertyCreation(LinkMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateLinkMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2LinkmultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class NumberMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<NumberMultiValueExtendedPropertyCreationDto>
        {
            public NumberMultiValueExtendedPropertyCreation(NumberMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateNumberMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2NumbermultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class PersianDateMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<PersianDateMultiValueExtendedPropertyCreationDto>
        {
            public PersianDateMultiValueExtendedPropertyCreation(PersianDateMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreatePersianDateMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2PersiandatemultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class ProductMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<ProductMultiValueExtendedPropertyCreationDto>
        {
            public ProductMultiValueExtendedPropertyCreation(ProductMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateProductMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2ProductmultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class SecurityItemMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<SecurityItemMultiValueExtendedPropertyCreationDto>
        {
            public SecurityItemMultiValueExtendedPropertyCreation(SecurityItemMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateSecurityItemMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2SecurityitemmultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class TextMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<TextMultiValueExtendedPropertyCreationDto>
        {
            public TextMultiValueExtendedPropertyCreation(TextMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateTextMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2TextmultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }
        private class UserMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<UserMultiValueExtendedPropertyCreationDto>
        {
            public UserMultiValueExtendedPropertyCreation(UserMultiValueExtendedPropertyCreationDto property, IPayamGostarApiProviderFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                try
                {
                    var clientApi = ClientFactory.CreateUserMultiValuePropertyDefinitionApiClient();

                    return await clientApi.PostApiV2UsermultivaluepropertydefinitionCreateAsync(Property.ToVM());
                }
                catch (ApiException e)
                {
                    throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(Property));
                }
            }
        }

        /* 
        CrmItemIdentityExtendedPropertyCreationDto
        GpExtendedPropertyCreationDto
        GregorianDateExtendedPropertyCreationDto
        HTMLExtendedPropertyCreationDto
        ImageExtendedPropertyCreationDto
        LinkExtendedPropertyCreationDto
        MarketingCampaignExtendedPropertyCreationDto

        AppointmentExtendedPropertyCreation
        AutoNumberExtendedPropertyCreation
        CheckboxExtendedPropertyCreation
        CurrencyExtendedPropertyCreation
        DepartmentExtendedPropertyCreation
        DropDownListExtendedPropertyCreation
        FileExtendedPropertyCreation
        FormExtendedPropertyCreation
        LabelExtendedPropertyCreation
        NumberExtendedPropertyCreation
        PersianDateExtendedPropertyCreation
        PositionExtendedPropertyCreation
        SecurityItemExtendedPropertyCreation
        TextExtendedPropertyCreation
        TimeExtendedPropertyCreation
        UserExtendedPropertyCreation

        CrmObjectMultiValueExtendedPropertyCreation
        CurrencyMultiValueExtendedPropertyCreationDto
        FileMultiValueExtendedPropertyCreationDto
        GregorianDateMultiValueExtendedPropertyCreationDto
        IdentityMultiValueExtendedPropertyCreationDto
        LinkMultiValueExtendedPropertyCreationDto
        NumberMultiValueExtendedPropertyCreationDto
        PersianDateMultiValueExtendedPropertyCreationDto
        ProductMultiValueExtendedPropertyCreationDto
        SecurityItemMultiValueExtendedPropertyCreationDto
        TextMultiValueExtendedPropertyCreationDto
        UserMultiValueExtendedPropertyCreationDto
         */
    }

}
