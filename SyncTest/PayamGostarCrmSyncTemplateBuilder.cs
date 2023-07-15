using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Sync;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SyncTest
{

    public class PayamGostarCrmSyncTemplateBuilder : ICrmSyncTemplateBuilder
    {
        public const string DEFAULT_LANGUAGE_CULTURE = "fa-ir";


        private string LanguageCulture { get; }

        private readonly ICollection<ICustomizationCrmModel> _crmModels;
        private readonly ICollection<NumberingTemplateModel> _numberingTemplateModels;
        private readonly IDictionary<Gp_CrmObjectType, CrmGeneralModel> _crmGeneralModelsMapper;


        public PayamGostarCrmSyncTemplateBuilder() : this(DEFAULT_LANGUAGE_CULTURE)
        {

        }

        public PayamGostarCrmSyncTemplateBuilder(string languageCulture)
        {
            LanguageCulture = languageCulture;
            _crmModels = new List<ICustomizationCrmModel>();
            _numberingTemplateModels = new List<NumberingTemplateModel>();
            _crmGeneralModelsMapper = new Dictionary<Gp_CrmObjectType, CrmGeneralModel>();
        }


        public IEnumerable<ICustomizationCrmModel> GetCrmModels()
        {
            return _numberingTemplateModels
                .Cast<ICustomizationCrmModel>()
                .Union(_crmGeneralModelsMapper.Values)
                .Union(_crmModels);
        }


        public void CreateTextExtendedProperty(GeneralPropertySyncDto syncDto)
        {

            var isCrmGeneralExist = _crmGeneralModelsMapper.TryGetValue(syncDto.Type, out CrmGeneralModel crmGeneralModel);

            if (!isCrmGeneralExist)
            {
                crmGeneralModel = new CrmGeneralModel
                {
                    Type = syncDto.Type,
                };

                _crmGeneralModelsMapper.Add(crmGeneralModel.Type, crmGeneralModel);
            }

            var group = crmGeneralModel
                .PropertyGroups
                .Where(pg => pg.Name.Where(n => n.Value == syncDto.PropertyGroup.Name).Any())
                .FirstOrDefault();

            if (group == null)
            {
                group = new PropertyGroup
                {
                    Name = CreateResourceValue(syncDto.PropertyGroup.Name),
                    CountOfColumns = syncDto.PropertyGroup.CountOfColumns,
                    Expanded = syncDto.PropertyGroup.Expanded,
                };

                crmGeneralModel.PropertyGroups.Add(group);
            }

            var newTextExtendedProperty = FillExtendedProperty(new TextExtendedPropertyModel
            {
                PropertyGroup = group,

            }, syncDto.PropertyGroup.PropertySyncDto);

            crmGeneralModel.Properties.Add(newTextExtendedProperty);


           
        }

        public void CreateFormModel()
        {
        }

        public void CreateOrganizationIdentityModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var identityModel = new CrmIdentityModel
            {
                Name = CreateResourceValue(syncDto.Name),
                Code = syncDto.Code,
                PreviewTypeIndex = Gp_PreviewType.WordPreview,
                NumberingTemplate = numberingTemplate,

                ProfileType = Gp_ProfileType.Customer,
                IdentityFunctionIndex = Gp_IdentityFunction.Contact,
                IdentityTypeIndex = Gp_IdentityType.Organization,
            };

            _crmModels.Add(identityModel);
        }

        public void CreatePersonIdentityModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var identityModel = new CrmIdentityModel
            {
                Name = CreateResourceValue(syncDto.Name),
                Code = syncDto.Code,
                PreviewTypeIndex = Gp_PreviewType.WordPreview,
                NumberingTemplate = numberingTemplate,

                ProfileType = Gp_ProfileType.Customer,
                IdentityFunctionIndex = Gp_IdentityFunction.Contact,
                IdentityTypeIndex = Gp_IdentityType.Person,
            };

            _crmModels.Add(identityModel);
        }

        public void CreateInvoiceModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);
        }

        public void CreateNumberingTemplateModel(NumberingTemplateSyncDto syncDto)
        {
            var model = CreateNumberingTemplate(syncDto);

            _numberingTemplateModels.Add(model);
        }

        public void CreatePaymentModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBasePaymentModel(new CrmPaymentModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreatePurchaseInvoiceModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmPurchaseInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);
        }

        public void CreatePurchaseQuoteModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmPurchaseQuoteModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreateQuoteModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmQuoteModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreateReceiptModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBasePaymentModel(new CrmReceiptModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreateReturnPurchaseInvoiceModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmReturnPurchaseInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreateReturnSaleInvoiceModel(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateAndAddTemplateNumberIfDoesNotExist(syncDto);

            var baseInvoiceModel = FillDefaultCrmBaseInvoiceModel(new CrmReturnSaleInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            }, syncDto);

            _crmModels.Add(baseInvoiceModel);

        }

        public void CreateTicketModel()
        {
        }


        private NumberingTemplateModel CreateAndAddTemplateNumberIfDoesNotExist(CrmObjectSyncDto syncDto)
        {
            var numberingTemplate = CreateNumberingTemplate(syncDto.NumberingTemplate);

            var result = _numberingTemplateModels
                .Where(x => CompareNumberingTemplate(x, numberingTemplate))
                .FirstOrDefault();

            if (result == null)
            {
                _numberingTemplateModels.Add(numberingTemplate);

                result = numberingTemplate;
            }

            return result;
        }

        private static NumberingTemplateModel CreateNumberingTemplate(NumberingTemplateSyncDto syncDto)
        {
            return new NumberingTemplateModel
            {
                Name = syncDto.Name,
                Prefix = syncDto.Prefix,
                InitialSeed = syncDto.InitialSeed,
                LastNumber = syncDto.LastNumber,
                ResetNumberInNewPrefix = syncDto.ResetNumberInNewPrefix,
            };
        }

        private bool CompareNumberingTemplate(NumberingTemplateModel oldModel, NumberingTemplateModel newModel)
        {
            return
                oldModel.Prefix.Trim().Equals(newModel.Prefix.Trim()) &&
                oldModel.Name.Trim().Equals(newModel.Name.Trim());
        }

        private T FillDefaultCrmBaseInvoiceModel<T>(T model, CrmObjectSyncDto syncDto) where T : CrmBaseInvoiceModel
        {
            model.Name = CreateResourceValue(syncDto.Name);
            model.Code = syncDto.Code;
            model.PreviewTypeIndex = Gp_PreviewType.WordPreview;

            model.AdditionalCosts = new AdditionalCostModel
            {
                AdditionalCostsTitle = string.Empty,
                AdditionalCostIncludedTax = false,
                AdditionalCostIncludedToll = false,
                AdditionalCostsPlacement = Gp_AdditionalCostsPlacementType.OnFinalPrice,
                InvoiceAdditionalCost = Gp_InvoiceAdditionalCostType.Percentage,
            };

            return model;
        }

        private T FillDefaultCrmBasePaymentModel<T>(T model, CrmObjectSyncDto syncDto) where T : CrmBasePaymentModel
        {
            model.Name = CreateResourceValue(syncDto.Name);
            model.Code = syncDto.Code;
            model.PreviewTypeIndex = Gp_PreviewType.WordPreview;

            return model;
        }

        private ResourceValue[] CreateResourceValue(string name)
        {
            return new[] { new ResourceValue { LanguageCulture = LanguageCulture, Value = name } };
        }


        private T FillExtendedProperty<T>(T model, BaseExtendedPropertySyncDto syncDto) where T : BaseExtendedPropertyModel
        {
            model.UserKey = syncDto.UserKey;
            model.Name = CreateResourceValue(syncDto.Name);

            return model;
        }
    }
}
