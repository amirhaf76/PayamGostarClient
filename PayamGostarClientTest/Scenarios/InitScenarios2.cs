using FluentAssertions;
using Moq;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Services;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class InitScenarios2 : BaseTestScenario
    {
        public InitScenarios2(ITestOutputHelper testOutput) : base(testOutput)
        {
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
                .ReturnsAsync(MockTestExtension.CreateApiResponse(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable()));

            object request = null;

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                .Callback<CrmObjectTypeFormCreateRequestDto>(x =>request = x)
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new CrmObjectTypeResultDto { Id  = Guid.NewGuid() }));

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

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
                .ReturnsAsync(MockTestExtension.CreateApiResponse(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable()));

            object request = null;
            var crmObjectTypeId = Guid.NewGuid();
            var groupId = 5024;

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new CrmObjectTypeResultDto { Id = crmObjectTypeId }));

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()))
                .Callback<CrmObjectPropertyGroupCreationRequestDto>(x => request = x)
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new CrmObjectPropertyGroupCreationResultDto { Id = groupId }));

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

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
                .ReturnsAsync(MockTestExtension.CreateApiResponse(Array.Empty<CrmObjectTypeSearchResultDto>().AsEnumerable()));

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.Is<CrmObjectTypeSearchRequestDto>(x => x.IsAbstract)))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new[]
                {
                    new CrmObjectTypeSearchResultDto
                    {
                        Id = superObject,
                        Properties = Array.Empty<ExtendedPropertyGetResultDto>(),
                        Groups = Array.Empty<PropertyGroupGetResultDto>(),
                    }
                }.AsEnumerable()));

            var request = new List<object>();
            var crmObjectTypeId = Guid.NewGuid();
            var groupId = 5024;

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.FormApi.CreateAsync(It.IsAny<CrmObjectTypeFormCreateRequestDto>()))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new CrmObjectTypeResultDto { Id = crmObjectTypeId }));

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.IsAny<CrmObjectPropertyGroupCreationRequestDto>()))
                .Callback<CrmObjectPropertyGroupCreationRequestDto>(x => request.Add(x))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new CrmObjectPropertyGroupCreationResultDto { Id = groupId }));

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.ExtendedPropertyApi.CreateAsync(It.IsAny<BaseExtendedPropertyDto>()))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new PropertyDefinitionCreationResultDto { Id = superObject }));

            var initService = new FormInitService(model, mockPayamGostarClient.Object);

            var service = mockPayamGostarClient.Object.CustomizationApi.CrmObjectTypeApi;

            TestOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            TestOutput.WriteLine($"Code: {model.Code}");

            // Action.
            await initService.InitAsync();

            // Assertion 
            request.Should().BeEquivalentTo(new[]
            {
                new 
                {
                    Name = new
                    {
                        ResourceValues = model.PropertyGroups[0].Name
                    },
                    CountOfColumns = 2,
                    ExpandForView = false,

                },
                new
                {
                    Name = new
                    {
                        ResourceValues = model.PropertyGroups[1].Name
                    },
                    CountOfColumns = 2,
                    ExpandForView = false,
           
                }
            });

            mockPayamGostarClient
                .Verify(
                    expression: m => m.CustomizationApi.PropertyGroupApi.CreateAsync(It.Is<CrmObjectPropertyGroupCreationRequestDto>(x => x.CrmObjectTypeId == crmObjectTypeId)),
                    times: Times.Once);
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


    }
}
