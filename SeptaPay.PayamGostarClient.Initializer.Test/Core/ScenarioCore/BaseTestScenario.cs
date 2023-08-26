using SeptaPay.PayamGostarClient.Initializer.Core;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Test.Core.Settings;
using SeptaPay.PayamGostarClient.Initializer.Test.DataTestModels.CrmFormDataTests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SeptaPay.PayamGostarClient.Initializer.Test.Core.ScenarioCore
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
            var initServiceConfig = CreatePayamGostarClientServiceConfig();

            var crmModelInitializer = new CrmObjectModelInitializerRestApi(initServiceConfig);

            return crmModelInitializer;
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


        public async Task<IEnumerable<CrmObjectTypeSearchResultDto>> SearchModel(IPayamGostarCrmObjectTypeApiClient service, BaseCRMModel baseModel)
        {
            return await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = baseModel.Code, CrmOjectTypeIndex = (int)baseModel.Type });
        }
    }

}