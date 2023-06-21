using FluentAssertions;
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
    public class InitScenarios : BaseTestScenario
    {
        public InitScenarios(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithoutGroupAndProperties), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithoutGroupAndProperties_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault().Value,
                Code = model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
            });

        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithJustAGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithGroup_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
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
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithAGroupAndATextProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithGroupAndWithTextProperty_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
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
                        Name = model.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        UserKey = model.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndAProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModel_CreateSuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
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
                        Name = model.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        UserKey = model.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndAnExtraProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithNewTextProperty_CreateSuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                Code = existedModel.Code,
                CrmOjectTypeIndex = (int)existedModel.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = existedModel.PropertyGroups.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = existedModel.Properties.ElementAtOrDefault(0)?.Name.FirstOrDefault()?.Value,
                        UserKey = existedModel.Properties.ElementAtOrDefault(0)?.UserKey,
                    },
                    new
                    {
                        Name = existedModel.Properties.ElementAtOrDefault(1)?.Name.FirstOrDefault()?.Value,
                        UserKey = existedModel.Properties.ElementAtOrDefault(1)?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndJustAnExtraProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithJustNewTextProperty_CreateSuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarClientServiceFactory().CreateCrmObjectTypeService();

            await crmModelInitializer.InitAsync(model);

            // Assertion before.
            model.Properties.Should().HaveCount(1);

            existedModel.Properties.Should()
                .HaveCount(1)
                .And.BeEquivalentTo(new[]
                {
                    new
                    {
                        model.Properties.FirstOrDefault()?.Type
                    }
                })
                .And.NotBeEquivalentTo(new[]
                {
                    new
                    {
                        model.Properties.FirstOrDefault()?.UserKey
                    }
                });

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                Code = existedModel.Code,
                CrmOjectTypeIndex = (int)existedModel.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = existedModel.PropertyGroups.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = model.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        UserKey = model.Properties.FirstOrDefault()?.UserKey,
                    },
                    new
                    {
                        Name = existedModel.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        UserKey = existedModel.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithoutGroupAndPropertiesAndName), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithoutName_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                   // Action.
                   await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullNameException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithoutGroupAndPropertiesAndCode), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithoutCode_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullCrmCodeException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithSameUserKeys), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithSameUserKeys_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NonUniqeUserKeyException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithUnbindedPropertyToGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithUnbindedPropertyToGroup_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<UnBindedExtendedPropertyToGroupPropertyException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithEmptyExtendedUserKey), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithEmptyExtendedUserKey_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullPropertyUserKeyExcpetion>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithPropertyThatThereIsNotAnyGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithPropertyThatThereIsNotAnyGroup_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<InvalidGroupCountException>();
        }

    }
}
