using FluentAssertions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
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

            searchedObjectBefore.Result.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().BeEmpty();
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

            searchedObjectBefore.Result.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().BeEmpty();
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

            searchedObjectBefore.Result.Should().BeEmpty();

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(model);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().BeEmpty();
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

            searchedObjectBefore.Result.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
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

            searchedObjectBefore.Result.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
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

            searchedObjectBefore.Result.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.Result.FirstOrDefault().Groups);
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

            searchedObjectBefore.Result.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeTrue();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.Result.FirstOrDefault().Groups);
            searchedObjectAfter.Result.FirstOrDefault().Properties.Should().BeEquivalentTo(searchedObjectBefore.Result.FirstOrDefault().Properties);
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

            searchedObjectBefore.Result.Should().HaveCount(1);

            // Action.
            var doesSchemaExist = await crmModelInitializer.CheckExistenceSchemaAsync(existedModel);

            doesSchemaExist.Should().BeFalse();

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Groups.Should().BeEquivalentTo(searchedObjectBefore.Result.FirstOrDefault().Groups);
            searchedObjectAfter.Result.FirstOrDefault().Properties.Should().NotContainEquivalentOf(new[]
            {
                new
                {
                    Name = existedModel.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                    UserKey = existedModel.Properties.FirstOrDefault()?.UserKey,
                },
            });
        }



    }
}
