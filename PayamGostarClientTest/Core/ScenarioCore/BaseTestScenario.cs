using PayamGostarClient.ApiClient;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClientTest.Core.Settings;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PayamGostarClientTest.Core.ScenarioCore
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

        public PayamGostarApiClientConfig CreatePayamGostarClientServiceConfig()
        {
            var setting = TestSettingsDto;

            var receivedSettings = new PayamGostarApiClientConfig
            {
                Url = setting.Url,
                LanguageCulture = setting.LanguageCulture,
                JwToken = setting.JWT,
            };

            return receivedSettings;
        }

        public PayamGostarApiClient CreatePayamGostarApiClient()
        {
            var payamGostarClientServiceConfig = CreatePayamGostarClientServiceConfig();

            var apiServiceFactory = new PayamGostarApiClient(payamGostarClientServiceConfig);

            return apiServiceFactory;
        }


        public async Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchModel(IPayamGostarCrmObjectTypeApiClient service, BaseCRMModel baseModel)
        {
            return await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = baseModel.Code, CrmOjectTypeIndex = (int)baseModel.Type });
        }
    }

}