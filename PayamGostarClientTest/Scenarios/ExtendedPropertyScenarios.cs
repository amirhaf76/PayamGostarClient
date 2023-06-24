﻿using FluentAssertions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest.Scenarios
{
    public class ExtendedPropertyScenarios : BaseTestScenario
    {
        public ExtendedPropertyScenarios(ITestOutputHelper testOutput) : base(testOutput)
        {

        }

        [Theory]
        [MemberData(nameof(ExtendedPropertyDataTest.ASimpleCrmFormWithGroupAndTextExtendedProperty), MemberType = typeof(ExtendedPropertyDataTest))]
        public async Task ExtendedProperty_TextExtendedPropertyInSimpleForm_MustBeCreatedSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            model.Properties.FirstOrDefault().Should().BeAssignableTo<TextExtendedPropertyModel>();

            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            var theExtendedProperty = (TextExtendedPropertyModel)model.Properties.FirstOrDefault();

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault()?.Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                Code = model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = model.PropertyGroups.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        PropertyDisplayTypeIndex = (int)theExtendedProperty.Type,
                        UserKey = theExtendedProperty.UserKey,
                        IsRequired = theExtendedProperty.IsRequired,
                        DefaultValue = theExtendedProperty.DefaultValue,
                        Tooltip = theExtendedProperty.ToolTip.FirstOrDefault().Value,
                        Name = theExtendedProperty.Name.FirstOrDefault()?.Value,
                    }
                }
            });
        }


        [Theory]
        [MemberData(nameof(ExtendedPropertyDataTest.ASimpleCrmFormWithGroupAndASimpleDropDownListExtendedProperty), MemberType = typeof(ExtendedPropertyDataTest))]
        public async Task ExtendedProperty_DropDownListExtendedPropertyInSimpleForm_MustBeCreatedSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            model.Properties.FirstOrDefault().Should().BeAssignableTo<DropDownListExtendedPropertyModel>();

            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            var theExtendedProperty = (DropDownListExtendedPropertyModel)model.Properties.FirstOrDefault();

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault()?.Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                Code = model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = model.PropertyGroups.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        PropertyDisplayTypeIndex = (int)theExtendedProperty.Type,
                        UserKey = theExtendedProperty.UserKey,
                        IsRequired = theExtendedProperty.IsRequired,
                        DefaultValue = theExtendedProperty.DefaultValue,
                        Tooltip = theExtendedProperty.ToolTip.FirstOrDefault().Value,
                        Name = theExtendedProperty.Name.FirstOrDefault()?.Value,
                        //Values = theExtendedProperty.Values,
                    }
                }
            });
        }


        [Theory]
        [MemberData(nameof(ExtendedPropertyDataTest.ASimpleCrmFormWithGroupAndASimpleNumberExtendedProperty), MemberType = typeof(ExtendedPropertyDataTest))]
        public async Task ExtendedProperty_NumberExtendedPropertyInSimpleForm_MustBeCreatedSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            model.Properties.FirstOrDefault().Should().BeAssignableTo<NumberExtendedPropertyModel>();

            var theExtendedProperty = (NumberExtendedPropertyModel)model.Properties.FirstOrDefault();

            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault()?.Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                Code = model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = model.PropertyGroups.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        PropertyDisplayTypeIndex = (int)theExtendedProperty.Type,
                        UserKey = theExtendedProperty.UserKey,
                        IsRequired = theExtendedProperty.IsRequired,
                        DefaultValue = theExtendedProperty.DefaultValue,
                        Tooltip = theExtendedProperty.ToolTip.FirstOrDefault().Value,
                        Name = theExtendedProperty.Name.FirstOrDefault()?.Value,
                        ExtraConfig = new
                        {
                            theExtendedProperty.MinDigits,
                            theExtendedProperty.MaxDigits,
                            theExtendedProperty.MinValue,
                            theExtendedProperty.MaxValue,
                            theExtendedProperty.DecimalDigits,
                        }
                    }
                }
            });
        }
    }
}
