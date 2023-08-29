using FluentAssertions;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using Septa.PayamGostarClient.Initializer.Test.Core.ScenarioCore;
using Septa.PayamGostarClient.Initializer.Test.DataTestModels.CrmFormDataTests;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Septa.PayamGostarClient.Initializer.Test.Scenarios.IntegrationTest
{
    public class CheckExistenceSchemaScenarios : BaseTestScenario
    {
        public CheckExistenceSchemaScenarios(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.AnUnexistedSimpleFormModelWithoutGroupAndProperties), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnUnexistedSimpleFormModelWithoutGroupAndProperties_ReceiveFalse(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.AnUnexistedSimpleFormModelWithJustAGroup), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnUnexistedSimpleFormModelWithJustAGroup_ReceiveFalse(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.AnUnexistedSimpleFormModelWithAGroupAndATextProperty), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnUnexistedSimpleFormModelWithAGroupAndATextProperty_ReceiveFalse(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoUnexistedSimpleFormModelWithoutGroupAndProperties), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithoutGroupAndProperties_ReceiveTrue(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoUnexistedSimpleFormModelWithJustGroup), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithJustGroup_ReceiveTrue(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoUnexistedSimpleFormModelWithADifferentGroup), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithADifferentGroup_ReceiveTrue(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.FirstOrDefault().Groups);
        }


        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoUnexistedSimpleFormModelWithDifferentGroupAndSameTextProperty), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithDifferentGroupAndSameTextProperty_ReceiveTrue(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.FirstOrDefault().Groups);
            searchedObjectAfter.FirstOrDefault().Properties.Should().BeEquivalentTo(searchedObjectBefore.FirstOrDefault().Properties);
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoUnexistedSimpleFormModelWithSameGroupAndDifferentTextProperty), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithSameGroupAndDifferentTextProperty_ReceiveFalse(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.FirstOrDefault().Groups);
            searchedObjectAfter.FirstOrDefault().Properties.Should().NotContainEquivalentOf(new[]
            {
                new
                {
                    Name = existedModel.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                    existedModel.Properties.FirstOrDefault()?.UserKey,
                },
            });
        }

        

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoSimpleFormsWithEquivalentStages), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_TwoSimpleFormsWithEquivalentStages_ReceiveTrue(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Model validation
            model.Should().BeEquivalentTo(existedModel).And.NotBeSameAs(existedModel);

            await crmModelInitializer.InitAsync(model);

            // Action.
            var modificationStatus = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            // Assertion.
            modificationStatus.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoSimpleFormsWhichTheSecondOneHasOneMoreUnDoneStage), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        [MemberData(nameof(CheckExistenceSchemaDataTestCase.TwoSimpleFormsWhichTheSecondOneHasOneMoreDoneStage), MemberType = typeof(CheckExistenceSchemaDataTestCase))]
        public async Task CheckExistenceSchema_TwoSimpleFormsWhichTheSecondOneHasOneMore_ReceiveFalse(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Model validation
            existedModel.Stages.Should().HaveCount(c => c == model.Stages.Count + 1);

            await crmModelInitializer.InitAsync(model);

            // Action.
            var modificationStatus = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            // Assertion.
            modificationStatus.Should().BeFalse();
        }



    }
}
