using FluentAssertions;
using Moq;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Helper.Net;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Utilities.Comparers;
using PayamGostarClient.Initializer.Utilities.CreationStrategies;
using PayamGostarClient.Initializer.Utilities.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest.Scenarios.Unit
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
                    new PropertyGroupGetResultDto {Name = firstGroup.Name?.FirstOrDefault()?.Value, Id = 13 }
                });

            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), It.IsAny<PropertyGroup>()), times: Times.Once);
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), secondGroup), times: Times.Once);
            mockGroupClient.Verify(x => x.CreateGroupPropetyAsync(It.IsAny<Guid>(), firstGroup), times: Times.Never);

            mockGroupClient.VerifyNoOtherCalls();
        }

        [Fact]
        public void CheckMatchingBaseCrmObject_ASimpleCrmObjectModel_()
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

            var validator = new ModelMatchingValidator(mockChecker.Object);

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


        private ApiResponse<T> CreateApiResponse<T>(T obj)
        {
            return new ApiResponse<T>(HttpStatusCode.OK, obj);
        }
    }
}
