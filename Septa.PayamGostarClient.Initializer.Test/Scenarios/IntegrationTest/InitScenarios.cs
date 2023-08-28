using FluentAssertions;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
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

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault().Value,
                model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
            });

        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithJustAGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithGroup_TheGroupMustNotBeCreated(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = Enumerable.Empty<PropertyGroup>()
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithAGroupAndATextProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithGroupAndWithTextProperty_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault()?.Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                model.Code,
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
                        model.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithStages), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithStages_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().HaveCount(0);

            // Action.
            await crmModelInitializer.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault()?.Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                model.Code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
            });

            var stagesAssertionData = model.Stages
                .Select(x => new
                {
                    x.Key,
                    x.IsDoneStage,
                    Name = x.Name.FirstOrDefault()?.Value,
                    IsActive = x.Enabled,
                });

            searchedObjectAfter.FirstOrDefault().Stages.Should().BeEquivalentTo(stagesAssertionData);
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithUnDoneStages), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithStagesWithoutDoneStage_CreateSuccessfulyButRaiseAnExceptionForLackOfUnDoneStages(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            var initAction = new Func<Task>(async () =>
            {
                // Inner Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            await initAction.Should().ThrowExactlyAsync<NotFoundAtleastAFinalStageException>();

            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().HaveCount(1);
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithDoneStagesAndWithoutKeyForSomeOfThem), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithStagesThatHaveDoneStatAndWithoutKey_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            var initAction = new Func<Task>(async () =>
            {
                // Inner Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            await initAction.Should().ThrowExactlyAsync<NullStageKeyExcpetion>();

            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithStagesThatHaveNonUniqueKey), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithStagesThatHaveNonUniqueKey_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            var initAction = new Func<Task>(async () =>
            {
                // Inner Action.
                await crmModelInitializer.InitAsync(model);
            });

            // Assertion Before.
            var searchedObjectBefore = await SearchModel(service, model);

            searchedObjectBefore.Should().BeEmpty();

            // Action.
            await initAction.Should().ThrowExactlyAsync<NonUniqeStageKeyException>();

            var searchedObjectAfter = await SearchModel(service, model);

            searchedObjectAfter.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndAProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithAGroupAndAProperty_AddTheTextPropertySuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = model.Name.FirstOrDefault()?.Value,
                model.Code,
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
                        model.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndAnExtraProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithOldAndNewTextProperty_AddTheTextPropertySuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                existedModel.Code,
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
                        existedModel.Properties.ElementAtOrDefault(0)?.UserKey,
                    },
                    new
                    {
                        Name = existedModel.Properties.ElementAtOrDefault(1)?.Name.FirstOrDefault()?.Value,
                        existedModel.Properties.ElementAtOrDefault(1)?.UserKey,
                    }
                }
            });
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndJustAnExtraProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithJustNewTextProperty_AddTheTextPropertySuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

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

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                existedModel.Code,
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
                        model.Properties.FirstOrDefault()?.UserKey,
                    },
                    new
                    {
                        Name = existedModel.Properties.FirstOrDefault()?.Name.FirstOrDefault()?.Value,
                        existedModel.Properties.FirstOrDefault()?.UserKey,
                    }
                }
            });
        }


        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithThreeExistedStages), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithThreeExistedStage_JustCheckAndDoNothing(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                existedModel.Code,
                CrmOjectTypeIndex = (int)existedModel.Type,
                Enabled = true,
            });

            var stagesAssertionData = existedModel.Stages
                .Select(x => new
                {
                    x.Key,
                    x.IsDoneStage,
                    Name = x.Name.FirstOrDefault()?.Value,
                    IsActive = x.Enabled,
                });

            searchedObjectAfter.FirstOrDefault().Stages.Should().BeEquivalentTo(stagesAssertionData);
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithThreeExistedStagesAndNewUnDoneStage), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithThreeExistedStageAndNewUnDoneStage_JustNewStageMustBeAdded(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                existedModel.Code,
                CrmOjectTypeIndex = (int)existedModel.Type,
                Enabled = true,
            });

            var stagesAssertionData = existedModel.Stages
                .Select(x => new
                {
                    x.Key,
                    x.IsDoneStage,
                    Name = x.Name.FirstOrDefault()?.Value,
                    IsActive = x.Enabled,
                });

            searchedObjectAfter.FirstOrDefault().Stages.Should().BeEquivalentTo(stagesAssertionData);
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithThreeExistedStagesAndNewDoneStage), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithThreeExistedStageAndNewDoneStage_JustNewStageMustBeAdded(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var crmModelInitializer = CreateCrmObjectModelInitializer();

            var service = CreatePayamGostarApiClient().CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            await crmModelInitializer.InitAsync(model);

            // Action.
            await crmModelInitializer.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await SearchModel(service, existedModel);

            searchedObjectAfter.Should().HaveCount(1);
            searchedObjectAfter.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = existedModel.Name.FirstOrDefault()?.Value,
                existedModel.Code,
                CrmOjectTypeIndex = (int)existedModel.Type,
                Enabled = true,
            });

            var stagesAssertionData = existedModel.Stages
                .Select(x => new
                {
                    x.Key,
                    x.IsDoneStage,
                    Name = x.Name.FirstOrDefault()?.Value,
                    IsActive = x.Enabled,
                });

            searchedObjectAfter.FirstOrDefault().Stages.Should().BeEquivalentTo(stagesAssertionData);
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
            await initAction.Should().ThrowExactlyAsync<EmptyNameException>();
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
