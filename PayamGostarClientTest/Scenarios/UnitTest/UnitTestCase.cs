using FluentAssertions;
using Moq;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Services;
using PayamGostarClient.Initializer.Utilities.Comparers;
using PayamGostarClient.Initializer.Utilities.CreationStrategies;
using PayamGostarClient.Initializer.Utilities.Factory;
using PayamGostarClient.Initializer.Utilities.Validator;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using PayamGostarClientTest.DataTestModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest.Scenarios.UnitTest
{

    public class UnitTestCase
    {
        private readonly ITestOutputHelper _testOutput;

        public UnitTestCase(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void StagePriorityComparer_UnorderedStageBaseOnIsDoneStage_SortedStagesInWhichIsDoneStageComeFirst()
        {
            var comparer = StagePriorityComparer.GetInstance();

            var stages = new List<Stage>
            {
                new Stage
                {
                    Name = new[] {new ResourceValue { Value = "stage1", LanguageCulture = "fa-ir"} },
                    Key = "stageKey_1",
                    IsDoneStage = false,
                },
                new Stage
                {
                    Name = new[] {new ResourceValue { Value = "stage2", LanguageCulture = "fa-ir"} },
                    Key = "stageKey_2",
                    IsDoneStage = true,
                },
                new Stage
                {
                    Name = new[] {new ResourceValue { Value = "stage3", LanguageCulture = "fa-ir"} },
                    Key = "stageKey_3",
                    IsDoneStage = false,
                }
            };

            stages.Sort(comparer);

            stages.Should().SatisfyRespectively(
                s =>
                {
                    s.IsDoneStage.Should().BeTrue();
                    s.Should().BeSameAs(stages.FirstOrDefault(x => x.Key == "stageKey_2"));
                },
                s =>
                {
                    s.IsDoneStage.Should().BeFalse();
                },
                s =>
                {
                    s.IsDoneStage.Should().BeFalse();
                }
            );
        }

        [Fact]
        public async void CreateGroupPropetyAsync_SingleGroup_GroupCreationApiCallOnce()
        {

            var groupId = 10;

            var stubResponse = CreateApiResponse(new CrmObjectPropertyGroupCreationResultDto
            {
                Id = groupId
            });

            var group = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IPayamGostarPropertyGroupApiClient>();

            mockGroupClient
                .Setup(x => x.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()))
                .Callback(() => group.Id = groupId)
                .ReturnsAsync(stubResponse);

            var groupCreationStrategy = new GroupCreationStrategy(mockGroupClient.Object);

            var creationGroupRes = await groupCreationStrategy.CreateGroupPropetyAsync(Guid.NewGuid(), group);

            mockGroupClient.Verify(s => s.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()), times: Times.Once);
            mockGroupClient.VerifyNoOtherCalls();
        }

        [Fact]
        public async void CreateExtendedPropertiesAsync_PropertiesBelongSameUnexistedGroup_GroupCreationApiMustNeverBeCalled()
        {
            // Arrangement.
            var group = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IGroupCreationStrategy>();
            var mockExtendedProperty = new Mock<IPayamGostarExtendedPropertyApiClient>();

            mockGroupClient
                .Setup(x => x.CreateGroupPropetiesAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<PropertyGroup>>()))
                .ReturnsAsync((Guid x, IEnumerable<PropertyGroup> groups) =>
                {
                    var random = new Random();

                    foreach (var createdGroup in groups)
                    {
                        createdGroup.Id = random.Next();
                    }

                    return groups;
                });

            mockExtendedProperty
                .Setup(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(() => CreateApiResponse(new PropertyDefinitionCreationResultDto
                {
                    Id = Guid.NewGuid()
                }));

            var extendedPropertyCreationStrategy = new ExtendedPropertyCreationStrategy(mockExtendedProperty.Object, mockGroupClient.Object);

            // Action.
            await extendedPropertyCreationStrategy.CreateExtendedPropertiesAsync(
                Guid.NewGuid(),
                new[]
                {
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                });

            // Assertion.
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), It.IsAny<PropertyGroup>()), times: Times.Once);
            mockGroupClient.VerifyNoOtherCalls();
        }

        [Fact]
        public async void CreateExtendedPropertiesAsync_PropertiesBelongSameUnexistedGroup_PropertyCreationApiMustBeCalledAsManyAsPropertiesNumberAre()
        {
            var group = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IGroupCreationStrategy>();
            var mockExtendedProperty = new Mock<IPayamGostarExtendedPropertyApiClient>();

            mockGroupClient
                .Setup(x => x.CreateGroupPropetiesAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<PropertyGroup>>()))
                .ReturnsAsync((Guid x, IEnumerable<PropertyGroup> groups) =>
                {
                    var random = new Random();

                    foreach (var createdGroup in groups)
                    {
                        createdGroup.Id = random.Next();
                    }

                    return groups;
                });

            mockExtendedProperty
                .Setup(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(() => CreateApiResponse(new PropertyDefinitionCreationResultDto
                {
                    Id = Guid.NewGuid()
                }));

            var extendedPropertyCreationStrategy = new ExtendedPropertyCreationStrategy(mockExtendedProperty.Object, mockGroupClient.Object);

            await extendedPropertyCreationStrategy.CreateExtendedPropertiesAsync(
                Guid.NewGuid(),
                new[]
                {
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                });

            mockExtendedProperty.Verify(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()), times: Times.Exactly(4));

            mockExtendedProperty.VerifyNoOtherCalls();
        }

        [Fact]
        public async void CreateExtendedPropertiesAsync_PropertiesBelongSameExistedGroup_PropertyCreationApiMustBeCalledAsManyAsPropertiesNumberAre()
        {
            var group = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IGroupCreationStrategy>();
            var mockExtendedProperty = new Mock<IPayamGostarExtendedPropertyApiClient>();

            mockGroupClient
                .Setup(x => x.CreateGroupPropetiesAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<PropertyGroup>>()))
                .ReturnsAsync((Guid x, IEnumerable<PropertyGroup> groups) =>
                {
                    var random = new Random();

                    foreach (var createdGroup in groups)
                    {
                        createdGroup.Id = random.Next();
                    }

                    return groups;
                });

            mockExtendedProperty
                .Setup(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(() => CreateApiResponse(new PropertyDefinitionCreationResultDto
                {
                    Id = Guid.NewGuid()
                }));

            var extendedPropertyCreationStrategy = new ExtendedPropertyCreationStrategy(mockExtendedProperty.Object, mockGroupClient.Object);

            await extendedPropertyCreationStrategy.CreateExtendedPropertiesAsync(
                Guid.NewGuid(),
                new[]
                {
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                }, new[]
                {
                    new PropertyGroupGetResultDto { Name = group.Name?.FirstOrDefault()?.Value, }
                });
            
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), It.IsAny<PropertyGroup>()), times: Times.Never);
            mockExtendedProperty.Verify(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()), times: Times.Exactly(4));

            mockExtendedProperty.VerifyNoOtherCalls();
        }

        [Fact]
        public async void CreateExtendedPropertiesAsync_PropertiesBelongSameExistedGroup_GroupCreationApiMustNeverBeCalled()
        {
            // Arrangement.
            var group = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IGroupCreationStrategy>();
            var mockExtendedProperty = new Mock<IPayamGostarExtendedPropertyApiClient>();

            mockGroupClient
                .Setup(x => x.CreateGroupPropetiesAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<PropertyGroup>>()))
                .ReturnsAsync((Guid x, IEnumerable<PropertyGroup> groups) =>
                {
                    var random = new Random();

                    foreach (var createdGroup in groups)
                    {
                        createdGroup.Id = random.Next();
                    }

                    return groups;
                });

            mockExtendedProperty
                .Setup(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(() => CreateApiResponse(new PropertyDefinitionCreationResultDto
                {
                    Id = Guid.NewGuid()
                }));

            var extendedPropertyCreationStrategy = new ExtendedPropertyCreationStrategy(mockExtendedProperty.Object, mockGroupClient.Object);

            // Action.
            await extendedPropertyCreationStrategy.CreateExtendedPropertiesAsync(
                Guid.NewGuid(),
                new[]
                {
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                    new TextExtendedPropertyModel {PropertyGroup = group },
                },
                new[]
                {
                    new PropertyGroupGetResultDto {Name = group.Name?.FirstOrDefault()?.Value, Id = 13 }
                });

            // Assertion.
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), It.IsAny<PropertyGroup>()), times: Times.Never);

            mockGroupClient.VerifyNoOtherCalls();
        }

        [Fact]
        public async void CreateExtendedPropertiesAsync_PropertiesBelongToAnExistedAndAnUnexistedGroup_GroupCreationApiMustBeCalledOnceForUnexistedGroup()
        {
            // Arrangement
            var firstGroup = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var secondGroup = new PropertyGroup
            {
                Name = new[] { new ResourceValue { Value = "Name2", LanguageCulture = "fa-IR" } },
                Expanded = true,
                CountOfColumns = 2,
            };

            var mockGroupClient = new Mock<IGroupCreationStrategy>();
            var mockExtendedProperty = new Mock<IPayamGostarExtendedPropertyApiClient>();

            mockGroupClient
                .Setup(x => x.CreateGroupPropetiesAsync(It.IsAny<Guid>(), It.IsAny<IEnumerable<PropertyGroup>>()))
                .ReturnsAsync((Guid x, IEnumerable<PropertyGroup> groups) =>
                {
                    var random = new Random();

                    foreach (var createdGroup in groups)
                    {
                        createdGroup.Id = random.Next();
                    }

                    return groups;
                });

            mockExtendedProperty
                .Setup(x => x.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(() => CreateApiResponse(new PropertyDefinitionCreationResultDto
                {
                    Id = Guid.NewGuid()
                }));

            var extendedPropertyCreationStrategy = new ExtendedPropertyCreationStrategy(mockExtendedProperty.Object, mockGroupClient.Object);

            await extendedPropertyCreationStrategy.CreateExtendedPropertiesAsync(
                Guid.NewGuid(),
                new[]
                {
                    new TextExtendedPropertyModel { PropertyGroup = firstGroup },
                    new TextExtendedPropertyModel { PropertyGroup = firstGroup },
                    new TextExtendedPropertyModel { PropertyGroup = firstGroup },
                    new TextExtendedPropertyModel { PropertyGroup = secondGroup },
                    new TextExtendedPropertyModel { PropertyGroup = secondGroup },
                }, new[]
                {
                    new PropertyGroupGetResultDto { Name = firstGroup.Name?.FirstOrDefault()?.Value, }
                });

            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), It.IsAny<PropertyGroup>()), times: Times.Once);
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), secondGroup), times: Times.Once);
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), firstGroup), times: Times.Never);

            mockGroupClient.VerifyNoOtherCalls();
        }

        [Fact]
        public void CheckCrmMatchingBaseCrmObject_ASimpleCrmObjectModel_JustTypeAndCodeMustBeCalled()
        {
            // Arrangement
            var testId = Guid.NewGuid();

            var mockCrmFormModel = new CrmFormModel
            {
                Code = testId.ToString()
            };

            var mockCrmObjectTypeSearchResultDto = new CrmObjectTypeSearchResultDto
            {
                Code = testId.ToString(),
                CrmOjectTypeIndex = (int)mockCrmFormModel.Type,
            };

            var mockChecker = new Mock<IMatchingValidator>(MockBehavior.Strict);

            mockChecker
                .Setup(x => x.CheckFieldMatching(It.IsAny<It.IsAnyType>(), It.IsAny<It.IsAnyType>(), It.IsAny<string>()));

            var validator = new CrmModelMatchingValidator(mockChecker.Object);

            // Action.
            validator.CheckMatchingBaseCrmObject(mockCrmFormModel, mockCrmObjectTypeSearchResultDto);

            // Assertion.
            mockChecker.Verify(
                x => x.CheckFieldMatching(testId.ToString(), testId.ToString(), It.IsAny<string>()),
                times: Times.Once);

            mockChecker.Verify(
                x => x.CheckFieldMatching(
                    mockCrmFormModel.Type, (Gp_CrmObjectType)mockCrmObjectTypeSearchResultDto.CrmOjectTypeIndex, It.IsAny<string>()),
                times: Times.Once);

            mockChecker.VerifyNoOtherCalls();
        }

        [Fact]
        public void CheckNumberingMatchingBaseCrmObject_ASimpleCrmObjectModel_JustTypeAndCodeMustBeCalled()
        {
            // Arrangement
            var testId = Guid.NewGuid();

            var mockCrmFormModel = new CrmFormModel
            {
                Code = testId.ToString()
            };

            var mockCrmObjectTypeSearchResultDto = new CrmObjectTypeSearchResultDto
            {
                Code = testId.ToString(),
                CrmOjectTypeIndex = (int)mockCrmFormModel.Type,
            };

            var mockChecker = new Mock<IMatchingValidator>(MockBehavior.Strict);

            mockChecker
                .Setup(x => x.CheckFieldMatching(It.IsAny<It.IsAnyType>(), It.IsAny<It.IsAnyType>(), It.IsAny<string>()));

            var validator = new NumericCrmModelMatchingValidator(mockChecker.Object);

            // Action.
            validator.CheckMatchingBaseCrmObject(mockCrmFormModel, mockCrmObjectTypeSearchResultDto);

            // Assertion.
            mockChecker.Verify(
                x => x.CheckFieldMatching(testId.ToString(), testId.ToString(), It.IsAny<string>()),
                times: Times.Once);

            mockChecker.Verify(
                x => x.CheckFieldMatching(
                    mockCrmFormModel.Type, (Gp_CrmObjectType)mockCrmObjectTypeSearchResultDto.CrmOjectTypeIndex, It.IsAny<string>()),
                times: Times.Once);

            mockChecker.VerifyNoOtherCalls();
        }

        [Fact]
        public void CheckNumberingMatchingBaseCrmObject_ASimpleInvoiceCrmObjectModel_JustTypeAndCodeMustBeCalled()
        {
            // Arrangement
            var testId = Guid.NewGuid();
            var numberingTemplateId = 9;

            var mockCrmFormModel = new CrmInvoiceModel
            {
                Code = testId.ToString(),
                NumberingTemplate = new NumberingTemplateModel { Id = numberingTemplateId }
            };

            var mockCrmObjectTypeSearchResultDto = new CrmObjectTypeSearchResultDto
            {
                Code = testId.ToString(),
                CrmOjectTypeIndex = (int)mockCrmFormModel.Type,
                NumberingTemplateId = numberingTemplateId,
            };

            var mockChecker = new Mock<IMatchingValidator>(MockBehavior.Strict);

            mockChecker
                .Setup(x => x.CheckFieldMatching(It.IsAny<It.IsAnyType>(), It.IsAny<It.IsAnyType>(), It.IsAny<string>()));

            var validator = new NumericCrmModelMatchingValidator(mockChecker.Object);

            // Action.
            validator.CheckMatchingBaseCrmObject(mockCrmFormModel, mockCrmObjectTypeSearchResultDto);

            // Assertion.
            mockChecker.Verify(
                x => x.CheckFieldMatching(testId.ToString(), testId.ToString(), It.IsAny<string>()),
                times: Times.Once);

            mockChecker.Verify(
                x => x.CheckFieldMatching(
                    mockCrmFormModel.NumberingTemplate.Id, mockCrmObjectTypeSearchResultDto.NumberingTemplateId, It.IsAny<string>()),
                times: Times.Once);

            mockChecker.Verify(
                x => x.CheckFieldMatching(
                    mockCrmFormModel.Type, (Gp_CrmObjectType)mockCrmObjectTypeSearchResultDto.CrmOjectTypeIndex, It.IsAny<string>()),
                times: Times.Once);

            mockChecker.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CheckExistenceSchemaAsync_CrmFormModel_ShouldNotCreate()
        {
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>();

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsApiResponseAsync(new[]
                {
                    new CrmObjectTypeSearchResultDto
                    {
                        Id = Guid.NewGuid(),
                        Code = "Code_1",
                        Name = "Object_1",
                        Enabled = true,
                        IsAbstract = false,
                    }

                }.AsEnumerable());


            var crmFormModel = new CrmFormModel()
            {
                Code = "Code_2",
                Name = new[] { new ResourceValue { LanguageCulture = "fa-IR", Value = "Object_1" } }
            };

            var initService = new FormInitService(crmFormModel, mockPayamGostarClient.Object);

            await initService.CheckExistenceSchemaAsync();

            mockPayamGostarClient
                .Verify(m => m.CustomizationApi.CrmObjectTypeApi.FormApi, times: Times.Never);
        }

        [Fact]
        public async Task InitAsync_FormInitService_ThrowException()
        {
            // Arrangement.
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            mockPayamGostarClient.SetupAllProperties();

            var model = new CrmFormModel();

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await initService.InitAsync();
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullCrmCodeException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithUnbindedPropertyToGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithUnbindedPropertyToGroup_ThrowException(CrmFormModel model)
        {
            // Arrangement.
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            mockPayamGostarClient.SetupAllProperties();


            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await initService.InitAsync();
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<UnBindedExtendedPropertyToGroupPropertyException>();
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithoutGroupAndProperties), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithoutGroupAndProperties_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            mockPayamGostarClient.SetupAllProperties();
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsApiResponseAsync(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable());

            object request = null;

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                .Callback<CrmObjectTypeFormCreateRequestDto>(x => request = x)
                .ReturnsApiResponseAsync(new CrmObjectTypeResultDto { Id = Guid.NewGuid() });

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Action.
            await initService.InitAsync();

            // Assertion 
            request.Should().BeEquivalentTo(new
            {
                Name = new
                {
                    ResourceValues = model.Name
                },
                model.Code,
                Enabled = true,
            });

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()),
                    times: Times.Once);

        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithJustAGroup), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithGroup_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            mockPayamGostarClient.SetupAllProperties();
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsApiResponseAsync(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable());

            object request = null;
            var crmObjectTypeId = Guid.NewGuid();
            var groupId = 5024;

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                .ReturnsApiResponseAsync(new CrmObjectTypeResultDto { Id = crmObjectTypeId });

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()))
                .Callback<CrmObjectPropertyGroupCreationRequestDto>(x => request = x)
                .ReturnsApiResponseAsync(new CrmObjectPropertyGroupCreationResultDto { Id = groupId });

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Action.
            await initService.InitAsync();

            // Assertion 
            request.Should().BeNull();

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()),
                    times: Times.Never);
        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.SimpleFormModelWithAGroupAndATextPropertyAndASuperTextProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_SimpleFormModelWithTextPropertyAndSuperTextProperty_CreateSuccessfuly(CrmFormModel model)
        {
            // Arrangement.
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            var superObject = Guid.NewGuid();

            mockPayamGostarClient.SetupAllProperties();
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.Is<CrmObjectTypeSearchRequestDto>(x => !x.IsAbstract)))
                .ReturnsApiResponseAsync(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable());

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.Is<CrmObjectTypeSearchRequestDto>(x => x.IsAbstract)))
                .ReturnsApiResponseAsync(new[]
                {
                    new CrmObjectTypeSearchResultDto
                    {
                        Id = superObject,
                        Properties = Array.Empty<ExtendedPropertyGetResultDto>(),
                        Groups = Array.Empty<PropertyGroupGetResultDto>(),
                    }
                }.AsEnumerable());

            SetUpFormApiCreateAsync(mockPayamGostarClient);

            SetUpPropertyGroupApiCreateAsync(mockPayamGostarClient);

            SetUpExtendedPropertyApiCreateAsync(mockPayamGostarClient);

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Action.
            await initService.InitAsync();

            // Assertion 

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.Is<CrmObjectPropertyGroupCreationRequestDto>(x => x.CrmObjectTypeId == superObject)),
                    times: Times.Once);

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()),
                    times: Times.Exactly(2));

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.ExtendedPropertyApi.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()),
                    times: Times.Exactly(2));

        }

        [Theory]
        [MemberData(nameof(InitDataTestCase.ExistedSimpleFormModelWithAGroupAndAnExtraProperty), MemberType = typeof(InitDataTestCase))]
        public async Task InitAsync_ExistedSimpleFormModelWithOldAndNewTextProperty_AddTheTextPropertySuccessfuly(CrmFormModel model, CrmFormModel existedModel)
        {
            // Arrangement.
            var mockPayamGostarClient = CreateDefaultMockPayamGostarClient();

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsApiResponseAsync(new[]
                {
                    new CrmObjectTypeSearchResultDto
                    {
                        Id = Guid.NewGuid(),
                        Code = model.Code,
                        CrmOjectTypeIndex = (int)model.Type,
                        Properties = model.Properties.Select(x =>
                            new ExtendedPropertyGetResultDto
                            {
                                Id = Guid.NewGuid(),
                                UserKey = x.UserKey,
                                PropertyDisplayTypeIndex = (int)x.Type,
                                Name = x.Name.FirstOrDefault().Value,
                                Group = new PropertyGroupGetResultDto
                                {
                                    Id = new Random().Next(),
                                    Name = x.PropertyGroup.Name.FirstOrDefault().Value,
                                }
                            })
                    }
                });

            var crmModelInitializer = new InitServiceFactory(new MatchingValidator(), mockPayamGostarClient.Object);


            // Action.
            await crmModelInitializer.Create(existedModel).InitAsync();


            // Assertion After.
            mockPayamGostarClient
                .Verify(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()), times: Times.Never);

            mockPayamGostarClient
                .Verify(m => m.CustomizationApi.ExtendedPropertyApi.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()), times: Times.Once);

            mockPayamGostarClient
                .Verify(m => m.CustomizationApi.ExtendedPropertyApi.CreateAsync(It.Is<BaseExtendedPropertyDto>(x => x.UserKey == existedModel.Properties[1].UserKey)), times: Times.Once);
        }


        private static void SetUpFormApiCreateAsync(Mock<IPayamGostarApiClient> mockPayamGostarClient)
        {
            mockPayamGostarClient
                            .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                            .ReturnsApiResponseAsync(new CrmObjectTypeResultDto { Id = Guid.NewGuid() });
        }

        private static void SetUpExtendedPropertyApiCreateAsync(Mock<IPayamGostarApiClient> mockPayamGostarClient)
        {
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.ExtendedPropertyApi.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsApiResponseAsync(new PropertyDefinitionCreationResultDto { Id = Guid.NewGuid() });
        }

        private static void SetUpPropertyGroupApiCreateAsync(Mock<IPayamGostarApiClient> mockPayamGostarClient)
        {
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()))
                .ReturnsApiResponseAsync(new CrmObjectPropertyGroupCreationResultDto { Id = new Random().Next() });
        }

        private static Mock<IPayamGostarApiClient> CreateDefaultMockPayamGostarClient()
        {
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>
            {
                DefaultValue = DefaultValue.Mock,
            };

            var superObject = Guid.NewGuid();

            mockPayamGostarClient.SetupAllProperties();
            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsApiResponseAsync(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable());

            SetUpPropertyGroupApiCreateAsync(mockPayamGostarClient);

            SetUpExtendedPropertyApiCreateAsync(mockPayamGostarClient);

            return mockPayamGostarClient;
        }


        private ApiResponse<T> CreateApiResponse<T>(T obj)
        {
            return new ApiResponse<T>(HttpStatusCode.OK, obj);
        }
    }
}
