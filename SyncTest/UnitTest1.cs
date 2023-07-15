using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SyncTest
{
    public class UnitTest1
    {

        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            var builder = new PayamGostarCrmSyncTemplateBuilder();

            var director = new FinancialCrmSyncTemplateDirector();

            director.MakeSepidarCrmSyncTemplate(builder);

            var crmModels = builder.GetCrmModels();

            foreach (var crm in crmModels)
            {
                _testOutputHelper.WriteLine("type: {0}", crm.CustomizationCrmType);

                if (crm.CustomizationCrmType == CustomizationCrmType.NumberingTemplate)
                {
                    var numberTemplate = (NumberingTemplateModel)crm;

                    _testOutputHelper.WriteLine("\tnum: {0}, {1}", numberTemplate.Name, numberTemplate.Prefix);
                }

                if (crm.CustomizationCrmType == CustomizationCrmType.GeneralCrmObjectType)
                {
                    var generalModel = (CrmGeneralModel)crm;

                    _testOutputHelper.WriteLine("\tgen prop: {0}", generalModel.Type);
                }

                if (crm.CustomizationCrmType == CustomizationCrmType.CrmObjectType)
                {
                    var crmModel = (BaseCRMModel)crm;

                    _testOutputHelper.WriteLine("\tcrm type: {0}, {1}", crmModel.Type, crmModel.Code);
                }
            }
        }

        [Fact]
        public async Task Test2()
        {
            var builder = new PayamGostarCrmSyncTemplateBuilder();

            var director = new FinancialCrmSyncTemplateDirector();

            director.MakeSepidarCrmSyncTemplate(builder);

            var crmModels = builder.GetCrmModels();

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = "http://pgonline-dev.com",
                    //Url = "https://webhook.site/f7beebfa-b533-40cc-a39e-c90790b57a63",
                    LanguageCulture = "fa-ir",
                   // BasicParam = "YWRtaW46YWRtaW4="
                   JwToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImQ2NWE1OTg2LWIwZGUtNDQzZi1iOGY3LTg5ZjYxMDEwZjNmNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vYWNjZXNzY29udHJvbHNlcnZpY2UvMjAxMC8wNy9jbGFpbXMvaWRlbnRpdHlwcm92aWRlciI6IlBHIEFTUC5ORVQgSWRlbnRpdHkiLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6ImQ2NWE1OTg2LWIwZGUtNDQzZi1iOGY3LTg5ZjYxMDEwZjNmNiIsImVtYWlsIjoia2F0QGdtYWlsLmNvbSIsImlkZW50aXR5VHlwZSI6IlBlcnNvbiIsIm5iZiI6MTY4NzI3Mzk3NCwiZXhwIjoxNjg5ODY1OTc0LCJpc3MiOiJQYXlhbUdvc3Rhci5jb20iLCJhdWQiOiJhbGwifQ.IzY-NMstcT8Br4xMo5IXMsqvHDjt_2Ntlc6svg66vlk",
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            await crmModelService.InitAsync(Log, crmModels.ToArray());
        }

        private void Log(ICustomizationCrmModel crm)
        {
            _testOutputHelper.WriteLine("type: {0}", crm.CustomizationCrmType);

            if (crm.CustomizationCrmType == CustomizationCrmType.NumberingTemplate)
            {
                var numberTemplate = (NumberingTemplateModel)crm;

                _testOutputHelper.WriteLine("\tnum: {0}, {1}", numberTemplate.Name, numberTemplate.Prefix);
            }

            if (crm.CustomizationCrmType == CustomizationCrmType.GeneralCrmObjectType)
            {
                var generalModel = (CrmGeneralModel)crm;

                _testOutputHelper.WriteLine("\tgen prop: {0}", generalModel.Type);
            }

            if (crm.CustomizationCrmType == CustomizationCrmType.CrmObjectType)
            {
                var crmModel = (BaseCRMModel)crm;

                _testOutputHelper.WriteLine("\tcrm type: {0}, {1}", crmModel.Type, crmModel.Code);
            }
        }
    }
}