using FluentAssertions;
using PayamGostarClient.Initializer;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class UnitTest2
    {
        private readonly ITestOutputHelper _testOutput;

        public UnitTest2(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_TicketmModel_InterviewTicket()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);


            await crmModelService.InitAsync(EmploymentRequestAdModel.Create(), EmploymentRequestModel.Create(), InterviewTicketModel.Create(System.Guid.Parse("fba40758-49ab-41dd-ba11-07e022a5e3bc")));

        }

     
        [Fact]
        public async Task InitAsync_EmploymentRequestCrmFormModel()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestModel.Create());
        }

        [Fact]
        public async Task InitAsync_EmploymentRequestAdModel()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestAdModel.Create());
        }
    }
}
