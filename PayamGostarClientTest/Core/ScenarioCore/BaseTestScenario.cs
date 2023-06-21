using PayamGostarClient.ApiServices;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class BaseTestScenario
    {
        protected ITestOutputHelper TestOutput { get; }

        protected static TestSettingsDto TestSettingsDto { get; private set; }

        static BaseTestScenario()
        {
            TestSettingsDto = new TestSettings().GetSettings();
        }

        public BaseTestScenario(ITestOutputHelper testOutput)
        {
            TestOutput = testOutput;

            DataTest.LANGUAGE_CULTURE = TestSettingsDto.LanguageCulture;
        }


        public CrmObjectModelInitializer CreateCrmObjectModelInitializer()
        {
            var initServiceConfig = CreateCrmObjectModelInitializerConfig();

            var crmModelInitializer = new CrmObjectModelInitializer(initServiceConfig);
            return crmModelInitializer;
        }

        public CrmObjectModelInitializerConfig CreateCrmObjectModelInitializerConfig()
        {
            var payamGostarClientServiceConfig = CreatePayamGostarClientServiceConfig();

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            return initServiceConfig;
        }

        public PayamGostarClientServiceConfig CreatePayamGostarClientServiceConfig(bool ReadFromCatch = true)
        {
            var setting = TestSettingsDto;

            var receivedSettings = new PayamGostarClientServiceConfig
            {
                Url = setting.Url,
                LanguageCulture = setting.LanguageCulture,
                JwToken = setting.JWT,
            };

            return receivedSettings;
        }

        public PayamGostarClientServiceFactory CreatePayamGostarClientServiceFactory()
        {
            var payamGostarClientServiceConfig = CreatePayamGostarClientServiceConfig();

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            return apiServiceFactory;
        }


        public async Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchModel(ICrmObjectTypeService service, BaseCRMModel baseModel)
        {
            return await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = baseModel.Code, CrmOjectTypeIndex = (int)baseModel.Type });
        }
    }

}