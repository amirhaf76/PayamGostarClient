using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiServices.Extension;
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
                case ExtendedPropertyType.AutoNumer:
                    return new AutoNumerExtendedPropertyCreation((AutoNumerExtendedPropertyCreationDto)baseProperty, _clientFactory);

                case ExtendedPropertyType.Checkbox:
                    return new CheckboxExtendedPropertyCreation((CheckboxExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Color:
                    return new ColorExtendedPropertyCreation((ColorExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.CrmItemIdentity:
                    return new CrmItemIdentityExtendedPropertyCreation((CrmItemIdentityExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.CrmItem:
                    return new CrmItemExtendedPropertyCreation((CrmItemExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.CrmObjectMultiValue:
                    return new CrmObjectMultiValueExtendedPropertyCreation((CrmObjectMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.CurrencyMultiValue:
                    return new CurrencyMultiValueExtendedPropertyCreation((CurrencyMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Currency:
                    return new CurrencyExtendedPropertyCreation((CurrencyExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.DropDownList:
                    return new DropDownListExtendedPropertyCreation((DropDownListExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.FileMultiValue:
                    return new FileMultiValueExtendedPropertyCreation((FileMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.File:
                    return new FileExtendedPropertyCreation((FileExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Gp:
                    return new GpExtendedPropertyCreation((GpExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.GregorianDateMultiValue:
                    return new GregorianDateMultiValueExtendedPropertyCreation((GregorianDateMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.GregorianDate:
                    return new GregorianDateExtendedPropertyCreation((GregorianDateExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.HTML:
                    return new HTMLExtendedPropertyCreation((HTMLExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.IdentityMultiValue:
                    return new IdentityMultiValueExtendedPropertyCreation((IdentityMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Image:
                    return new ImageExtendedPropertyCreation((ImageExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Label:
                    return new LabelExtendedPropertyCreation((LabelExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.LinkMultiValue:
                    return new LinkMultiValueExtendedPropertyCreation((LinkMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Link:
                    return new LinkExtendedPropertyCreation((LinkExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.MarketingCampaign:
                    return new MarketingCampaignExtendedPropertyCreation((MarketingCampaignExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.NumberMultiValue:
                    return new NumberMultiValueExtendedPropertyCreation((NumberMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Number:
                    return new NumberExtendedPropertyCreation((NumberExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.PersianDateMultiValue:
                    return new PersianDateMultiValueExtendedPropertyCreation((PersianDateMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.PersianDate:
                    return new PersianDateExtendedPropertyCreation((PersianDateExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.ProductMultiValue:
                    return new ProductMultiValueExtendedPropertyCreation((ProductMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.SecurityItemMultiValue:
                    return new SecurityItemMultiValueExtendedPropertyCreation((SecurityItemMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.SecurityItem:
                    return new SecurityItemExtendedPropertyCreation((SecurityItemExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.TextMultiValue:
                    return new TextMultiValueExtendedPropertyCreation((TextMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Text:
                    return new TextExtendedPropertyCreation((TextExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.Time:
                    return new TimeExtendedPropertyCreation((TimeExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.UserMultiValue:
                    return new UserMultiValueExtendedPropertyCreation((UserMultiValueExtendedPropertyCreationDto) baseProperty);

                case ExtendedPropertyType.User:
                    return new UserExtendedPropertyCreation((UserExtendedPropertyCreationDto) baseProperty);

                default:
                    throw new System.Exception();
            }


        }


        private abstract class BaseExtendedPropertyCreation<T> : IExtendedPropertyCreationService where T : BaseExtendedPropertyDto
        {
            protected T Property { get; }

            public BaseExtendedPropertyCreation(T property)
            {
                Property = property;
            }

            public abstract Task<object> CreateAsync();
        }


        private class AutoNumerExtendedPropertyCreation : BaseExtendedPropertyCreation<AutoNumerExtendedPropertyCreationDto>
        {
            private readonly IPayamGostarClientAbstractFactory _clientFactory;

            public AutoNumerExtendedPropertyCreation(AutoNumerExtendedPropertyCreationDto property, IPayamGostarClientAbstractFactory clientFactory) : base(property)
            {
                _clientFactory = clientFactory;
            }

            public override async Task<object> CreateAsync()
            {
                var clientApi = _clientFactory.CreateAutoNumberPropertyDefinitionApiClient();

                return await clientApi.PostApiV2AutonumberpropertydefinitionCreateAsync(new ApiProvider.AutoNumerPropertyDefinitionCreateVM
                {
                    Name = Property.Name.ToLocalizedResourceDto(),
                    UserKey = Property.UserKey,
                    PropertyGroupId = Property.PropertyGroupId,
                    AutoNumLength = Property.AutoNumLength,
                    CrmObjectTypeId = Property.CrmObjectTypeId,
                    DefaultValue = Property.DefaultValue,
                    Postfix = Property.Postfix,
                    Prefix = Property.Prefix,
                    Seed = Property.Seed,
                    ToolTip = Property.ToolTip.ToLocalizedResourceDto(),
                });
            }
        }
        private class CheckboxExtendedPropertyCreation : BaseExtendedPropertyCreation<CheckboxExtendedPropertyCreationDto>
        {
            public CheckboxExtendedPropertyCreation(CheckboxExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class ColorExtendedPropertyCreation : BaseExtendedPropertyCreation<ColorExtendedPropertyCreationDto>
        {
            public ColorExtendedPropertyCreation(ColorExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class CrmItemIdentityExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmItemIdentityExtendedPropertyCreationDto>
        {
            public CrmItemIdentityExtendedPropertyCreation(CrmItemIdentityExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class CrmItemExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmItemExtendedPropertyCreationDto>
        {
            public CrmItemExtendedPropertyCreation(CrmItemExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class CrmObjectMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<CrmObjectMultiValueExtendedPropertyCreationDto>
        {
            public CrmObjectMultiValueExtendedPropertyCreation(CrmObjectMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class CurrencyMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<CurrencyMultiValueExtendedPropertyCreationDto>
        {
            public CurrencyMultiValueExtendedPropertyCreation(CurrencyMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class CurrencyExtendedPropertyCreation : BaseExtendedPropertyCreation<CurrencyExtendedPropertyCreationDto>
        {
            public CurrencyExtendedPropertyCreation(CurrencyExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class DropDownListExtendedPropertyCreation : BaseExtendedPropertyCreation<DropDownListExtendedPropertyCreationDto>
        {
            public DropDownListExtendedPropertyCreation(DropDownListExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class FileMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<FileMultiValueExtendedPropertyCreationDto>
        {
            public FileMultiValueExtendedPropertyCreation(FileMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }

            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class FileExtendedPropertyCreation : BaseExtendedPropertyCreation<FileExtendedPropertyCreationDto>
        {
            public FileExtendedPropertyCreation(FileExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class GpExtendedPropertyCreation : BaseExtendedPropertyCreation<GpExtendedPropertyCreationDto>
        {
            public GpExtendedPropertyCreation(GpExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class GregorianDateMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<GregorianDateMultiValueExtendedPropertyCreationDto>
        {
            public GregorianDateMultiValueExtendedPropertyCreation(GregorianDateMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class GregorianDateExtendedPropertyCreation : BaseExtendedPropertyCreation<GregorianDateExtendedPropertyCreationDto>
        {
            public GregorianDateExtendedPropertyCreation(GregorianDateExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class HTMLExtendedPropertyCreation : BaseExtendedPropertyCreation<HTMLExtendedPropertyCreationDto>
        {
            public HTMLExtendedPropertyCreation(HTMLExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class IdentityMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<IdentityMultiValueExtendedPropertyCreationDto>
        {
            public IdentityMultiValueExtendedPropertyCreation(IdentityMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class ImageExtendedPropertyCreation : BaseExtendedPropertyCreation<ImageExtendedPropertyCreationDto>
        {
            public ImageExtendedPropertyCreation(ImageExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class LabelExtendedPropertyCreation : BaseExtendedPropertyCreation<LabelExtendedPropertyCreationDto>
        {
            public LabelExtendedPropertyCreation(LabelExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class LinkMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<LinkMultiValueExtendedPropertyCreationDto>
        {
            public LinkMultiValueExtendedPropertyCreation(LinkMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class LinkExtendedPropertyCreation : BaseExtendedPropertyCreation<LinkExtendedPropertyCreationDto>
        {
            public LinkExtendedPropertyCreation(LinkExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class MarketingCampaignExtendedPropertyCreation : BaseExtendedPropertyCreation<MarketingCampaignExtendedPropertyCreationDto>
        {
            public MarketingCampaignExtendedPropertyCreation(MarketingCampaignExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class NumberMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<NumberMultiValueExtendedPropertyCreationDto>
        {
            public NumberMultiValueExtendedPropertyCreation(NumberMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class NumberExtendedPropertyCreation : BaseExtendedPropertyCreation<NumberExtendedPropertyCreationDto>
        {
            public NumberExtendedPropertyCreation(NumberExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class PersianDateMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<PersianDateMultiValueExtendedPropertyCreationDto>
        {
            public PersianDateMultiValueExtendedPropertyCreation(PersianDateMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class PersianDateExtendedPropertyCreation : BaseExtendedPropertyCreation<PersianDateExtendedPropertyCreationDto>
        {
            public PersianDateExtendedPropertyCreation(PersianDateExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class ProductMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<ProductMultiValueExtendedPropertyCreationDto>
        {
            public ProductMultiValueExtendedPropertyCreation(ProductMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class SecurityItemMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<SecurityItemMultiValueExtendedPropertyCreationDto>
        {
            public SecurityItemMultiValueExtendedPropertyCreation(SecurityItemMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class SecurityItemExtendedPropertyCreation : BaseExtendedPropertyCreation<SecurityItemExtendedPropertyCreationDto>
        {
            public SecurityItemExtendedPropertyCreation(SecurityItemExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class TextMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<TextMultiValueExtendedPropertyCreationDto>
        {
            public TextMultiValueExtendedPropertyCreation(TextMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class TextExtendedPropertyCreation : BaseExtendedPropertyCreation<TextExtendedPropertyCreationDto>
        {
            public TextExtendedPropertyCreation(TextExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class TimeExtendedPropertyCreation : BaseExtendedPropertyCreation<TimeExtendedPropertyCreationDto>
        {
            public TimeExtendedPropertyCreation(TimeExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class UserMultiValueExtendedPropertyCreation : BaseExtendedPropertyCreation<UserMultiValueExtendedPropertyCreationDto>
        {
            public UserMultiValueExtendedPropertyCreation(UserMultiValueExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }
        }
        private class UserExtendedPropertyCreation : BaseExtendedPropertyCreation<UserExtendedPropertyCreationDto>
        {
            public UserExtendedPropertyCreation(UserExtendedPropertyCreationDto property) : base(property)
            {
            }
            public override Task<object> CreateAsync()
            {
                throw new System.NotImplementedException();
            }

        }

    }

}
