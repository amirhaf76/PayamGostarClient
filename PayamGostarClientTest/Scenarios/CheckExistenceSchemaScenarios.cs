using FluentAssertions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System;
using System.Collections.Generic;
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

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

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
        public async Task CheckExistenceSchema_AnUnexistedSimpleFormModelGroup_ReceiveFalse(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

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
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithoutGroupAndProperties_ReceiveFalse(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();
  
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
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithJustGroup_ReceiveFalse(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

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
        public async Task CheckExistenceSchema_AnExistedSimpleFormModelWithADifferentGroup_ReceiveFalse(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

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



    }
}
