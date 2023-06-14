using PayamGostarClient.CrmObjectModelInitServiceModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class UnitTest1
    {
        private const string URL = "http://pgonline-dev.com";
        //private const string URL = "https://webhook.site/eba279bf-0642-4288-9a82-b4e8d15fd276";
        private const string FA_LANGUAGE_CULTURE = "fa-IR";
        private const string EN_LANGUAGE_CULTURE = "en_US";

        private readonly ITestOutputHelper _testOutput;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_EmptyModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync();
        }

        [Fact]
        public async Task InitAsync_FormModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = AdminJwToken.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync(new CrmFormModel
            {
                Name = new ResourceValue[] 
                {
                    new ResourceValue { Value = "فرم تست ۱", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                
                Code = "Form_test_20230613"
            });
        }
    }


}