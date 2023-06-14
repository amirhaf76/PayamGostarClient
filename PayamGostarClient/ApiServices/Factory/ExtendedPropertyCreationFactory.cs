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
using System.Linq;
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

                
                default:
                    throw new ExtendedPropertyTypeNotFoundException();
            }
        }

        private IExtendedPropertyCreationService CreateExtendedPropertyCreationService<TService, TInputDto>(BaseExtendedPropertyDto baseExtended)
            where TService: BaseExtendedPropertyCreation<TInputDto>, IExtendedPropertyCreationService
            where TInputDto: BaseExtendedPropertyDto
        {
            return (IExtendedPropertyCreationService)Activator.CreateInstance(typeof(TService), (TInputDto) baseExtended, _clientFactory);
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


            public abstract Task<SwaggerResponse<PropertyDefinitionPostResultVM>>  CreatePropertyCreationActionAsync();

            public async Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync()
            {
                var propertyCreationTask = CreatePropertyCreationActionAsync();

                var propertyCreationResult = await propertyCreationTask.WrapInThrowableApiServiceExceptionAndInvoke().ConfigureAwait(false);

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
                var clientApi = ClientFactory.CreateTextPropertyDefinitionApiClient();

                return await clientApi.PostApiV2TextpropertydefinitionCreateAsync(Property.ToVM());
            }
        }
        private class FormExtendedPropertyCreation : BaseExtendedPropertyCreation<FormExtendedPropertyCreationDto>
        {
            public FormExtendedPropertyCreation(FormExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                var clientApi = ClientFactory.CreateFormPropertyDefinitionApiClient();

                return await clientApi.PostApiV2FormpropertydefinitionCreateAsync(Property.ToVM());
            }
        }
        private class DropDownListExtendedPropertyCreation : BaseExtendedPropertyCreation<DropDownListExtendedPropertyCreationDto>
        {
            public DropDownListExtendedPropertyCreation(DropDownListExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                var clientApi = ClientFactory.CreateDropDownListPropertyDefinitionApiClient();

                return await clientApi.PostApiV2DropdownlistpropertydefinitionCreateAsync(Property.ToVM());
            }
        }
        private class UserExtendedPropertyCreation : BaseExtendedPropertyCreation<UserExtendedPropertyCreationDto>
        {
            public UserExtendedPropertyCreation(UserExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property, clientFactory)
            {
            }

            public override async Task<SwaggerResponse<PropertyDefinitionPostResultVM>> CreatePropertyCreationActionAsync()
            {
                var clientApi = ClientFactory.CreateUserPropertyDefinitionApiClient();

                return await clientApi.PostApiV2UserpropertydefinitionCreateAsync(Property.ToVM());
            }
        }

    }

}
