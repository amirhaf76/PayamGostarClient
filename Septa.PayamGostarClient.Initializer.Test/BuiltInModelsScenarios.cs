using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels;
using Septa.PayamGostarClient.Initializer.Test.Core.ScenarioCore;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Septa.PayamGostarClient.Initializer.Test
{
    public class BuiltInModelsScenarios : BaseTestScenario
    {
        public BuiltInModelsScenarios(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public async Task InitAsync_TicketmModel_InterviewTicket()
        {
            var config = CreatePayamGostarClientServiceConfig();

            var crmModelService = new CrmObjectModelInitializerRestApi(config);

            await crmModelService.InitAsync(InterviewTicketModel.Create(Guid.Parse("3f47c91d-6604-493b-8801-6082036c4917")));
        }

        [Fact]
        public async Task InitAsync_EmploymentRequestCrmFormModel()
        {
            var config = CreatePayamGostarClientServiceConfig();

            var crmModelService = new CrmObjectModelInitializerRestApi(config);

            await crmModelService.InitAsync(EmploymentRequestModel.Create());
        }

        [Fact]
        public async Task InitAsync_EmploymentRequestAdModel()
        {
            var config = CreatePayamGostarClientServiceConfig();

            var crmModelService = new CrmObjectModelInitializerRestApi(config);

            await crmModelService.InitAsync(EmploymentRequestAdModel.Create());
        }

        [Fact]
        public async Task InitAsync_IdentityModel()
        {
            var config = CreatePayamGostarClientServiceConfig();

            var crmModelService = new CrmObjectModelInitializerRestApi(config);

            var numberingTemplate = new NumberingTemplateModel
            {
                Prefix = $"Algo_2_{{*(AN)}}",
                InitialSeed = 1,
                Name = $"Algo_2",
            };

            var identity = new CrmIdentityModel()
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = config.LanguageCulture, Value = $"identity"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = config.LanguageCulture, Value = string.Empty },
                },
                Code = $"Identity",
                NumberingTemplate = numberingTemplate,
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
                            new ResourceValue(){ LanguageCulture = config.LanguageCulture, Value = "اطلاعات آگهی"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    }
                },
            };


            await crmModelService.InitAsync(numberingTemplate, identity);
        }
    }
}
