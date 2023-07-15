using SyncTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.Sync
{
    public interface ICrmSyncTemplateBuilder
    {
        public void CreateTextExtendedProperty(GeneralPropertySyncDto syncDto);
        public void CreateFormModel();
        public void CreateOrganizationIdentityModel(CrmObjectSyncDto syncDto);
        public void CreatePersonIdentityModel(CrmObjectSyncDto syncDto);
        public void CreateInvoiceModel(CrmObjectSyncDto syncDto);
        public void CreateNumberingTemplateModel(NumberingTemplateSyncDto syncDto);
        public void CreatePaymentModel(CrmObjectSyncDto syncDto);
        public void CreatePurchaseInvoiceModel(CrmObjectSyncDto syncDto);
        public void CreatePurchaseQuoteModel(CrmObjectSyncDto syncDto);
        public void CreateQuoteModel(CrmObjectSyncDto syncDto);
        public void CreateReceiptModel(CrmObjectSyncDto syncDto);
        public void CreateReturnPurchaseInvoiceModel(CrmObjectSyncDto syncDto);
        public void CreateReturnSaleInvoiceModel(CrmObjectSyncDto syncDto);
        public void CreateTicketModel();

    }

    public interface ICrmSyncTemplateDirector
    {
        T MakeSepidarCrmSyncTemplate<T>(T builder) where T : ICrmSyncTemplateBuilder;
    }
}
