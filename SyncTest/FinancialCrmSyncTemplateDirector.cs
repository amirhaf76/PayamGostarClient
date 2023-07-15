using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Sync;
using System;
using System.Text;

namespace SyncTest
{
    public class FinancialCrmSyncTemplateDirector : ICrmSyncTemplateDirector
    {
        public const string NAME = "سپیدار";

        public T MakeSepidarCrmSyncTemplate<T>(T builder) where T : ICrmSyncTemplateBuilder
        {
            //builder.CreatePaymentModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.PAYMENT),
            //    Code = CrmObjectsCode.PAYMENT,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.PAYMENT,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.PAYMENT,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreateReceiptModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.RECEIPT),
            //    Code = CrmObjectsCode.RECEIPT,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.RECEIPT,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.RECEIPT,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreateInvoiceModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.INVOICE),
            //    Code = CrmObjectsCode.INVOICE,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.INVOICE,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.INVOICE,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreatePurchaseInvoiceModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.PURCHASE_INVOICE),
            //    Code = CrmObjectsCode.PURCHASE_INVOICE,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.PURCHASE_INVOICE,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.PURCHASE_INVOICE,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreateReturnPurchaseInvoiceModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.RETURN_PURCHASE_INVOICE),
            //    Code = CrmObjectsCode.RETURN_PURCHASE_INVOICE,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.RETURN_PURCHASE_INVOICE,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.RETURN_PURCHASE_INVOICE,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreateReturnSaleInvoiceModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.RETURN_SALE_INVOICE),
            //    Code = CrmObjectsCode.RETURN_SALE_INVOICE,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.RETURN_SALE_INVOICE,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.RETURN_SALE_INVOICE,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            //builder.CreateQuoteModel(new CrmObjectSyncDto
            //{
            //    Name = CreateName(CrmObjectsName.QUOTE),
            //    Code = CrmObjectsCode.QUOTE,
            //    NumberingTemplate = new NumberingTemplateSyncDto
            //    {
            //        Name = CrmObjectsNumberingTemplateName.QUOTE,
            //        Prefix = CrmObjectsNumberingTemplatePrefix.QUOTE,
            //        InitialSeed = 1,
            //        LastNumber = 1,
            //        ResetNumberInNewPrefix = true,
            //    }
            //});

            builder.CreateOrganizationIdentityModel(new CrmObjectSyncDto
            {
                Name = CreateName(CrmObjectsName.ORGANIZATION_IDENTITY),
                Code = CrmObjectsCode.ORGANIZATION_IDENTITY,
                NumberingTemplate = new NumberingTemplateSyncDto
                {
                    Name = CrmObjectsNumberingTemplateName.ORGANIZATION_IDENTITY,
                    Prefix = CrmObjectsNumberingTemplatePrefix.ORGANIZATION_IDENTITY,
                    InitialSeed = 1,
                    LastNumber = 1,
                    ResetNumberInNewPrefix = true,
                }
            });

            builder.CreatePersonIdentityModel(new CrmObjectSyncDto
            {
                Name = CreateName(CrmObjectsName.PERSON_IDENTITY),
                Code = CrmObjectsCode.PERSON_IDENTITY,
                NumberingTemplate = new NumberingTemplateSyncDto
                {
                    Name = CrmObjectsNumberingTemplateName.PERSON_IDENTITY,
                    Prefix = CrmObjectsNumberingTemplatePrefix.PERSON_IDENTITY,
                    InitialSeed = 1,
                    LastNumber = 1,
                    ResetNumberInNewPrefix = true,
                }
            });

            //builder.CreateTextExtendedProperty(new GeneralPropertySyncDto
            //{
            //    Type = Gp_CrmObjectType.Payment,
            //    PropertyGroup = new PropertyGroupSyncDto
            //    {
            //        Name = CrmObjectsGeneralGroupName.PAYMENT,
            //        CountOfColumns = 2,
            //        PropertySyncDto = new BaseExtendedPropertySyncDto
            //        {
            //            UserKey = "subpaymentid",
            //            Name = "شماره پرداخت فرعی",
            //        }
            //    }
            //});

            return builder;
        }

        private string CreateName(string name)
        {
            return $"{name} {NAME}";
        }
      
    }
}
