using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels;
using SeptaPay.PayamGostarClient.Initializer.Test.Constants;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SeptaPay.PayamGostarClient.Initializer.Test
{
    public class BuiltInModelsScenarios
    {
        private readonly ITestOutputHelper _testOutput;

        public BuiltInModelsScenarios(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_TicketmModel_InterviewTicket()
        {
            var initServiceConfig = new PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var crmModelService = new CrmObjectModelInitializerRestApi(initServiceConfig);


            await crmModelService.InitAsync(EmploymentRequestAdModel.Create(), EmploymentRequestModel.Create(), InterviewTicketModel.Create(Guid.Parse("fba40758-49ab-41dd-ba11-07e022a5e3bc")));

        }

        [Fact]
        public async Task InitAsync_EmploymentRequestCrmFormModel()
        {
            var initServiceConfig = new PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var crmModelService = new CrmObjectModelInitializerRestApi(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestModel.Create());
        }

        [Fact]
        public async Task InitAsync_EmploymentRequestAdModel()
        {
            var initServiceConfig = new PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var crmModelService = new CrmObjectModelInitializerRestApi(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestAdModel.Create());
        }

        [Fact]
        public async Task InitAsync_IdentityModel()
        {
            var initServiceConfig = new PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var crmModelService = new CrmObjectModelInitializerRestApi(initServiceConfig);

            var identity = new CrmIdentityModel()
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = $"identity_{Guid.NewGuid():N}"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = "Identity",

                IdentityTypeIndex = Gp_IdentityType.Person,
                IdentityFunctionIndex = Gp_IdentityFunction.Contact,
                ProfileType = Gp_ProfileType.Customer,
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "اطلاعات آگهی"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    }
                },
            };


            await crmModelService.InitAsync(identity);
        }
    }
}
