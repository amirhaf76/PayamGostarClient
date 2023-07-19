using FluentAssertions;
using Moq;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Services;
using PayamGostarClientTest.DataTestModels.CrmFormDataTests;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest.Scenarios.Unit
{
    public class UnitTestCase2
    {
        private readonly ITestOutputHelper _testOutput;

        public UnitTestCase2(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }


        [Fact]
        public async Task TaskAsync()
        {
            var mockPayamGostarClient = new Mock<IPayamGostarApiClient>();

            mockPayamGostarClient
                .Setup(m => m.CustomizationApi.CrmObjectTypeApi.SearchAsync(It.IsAny<CrmObjectTypeSearchRequestDto>()))
                .ReturnsAsync(MockTestExtension.CreateApiResponse(new[]
                {
                    new CrmObjectTypeSearchResultDto
                    {
                        Id = Guid.NewGuid(),
                        Code = "Code_1",
                        Name = "Object_1",
                        Enabled = true,
                        IsAbstract = false,
                    }

                }.AsEnumerable()));


            var crmFormModel = new CrmFormModel()
            { 
                Code = "Code_1",
                Name = new[] { new ResourceValue { LanguageCulture = "fa-IR", Value = "Object_1"} }
            };

            var initService = new FormInitService(crmFormModel, mockPayamGostarClient.Object);

            await initService.CheckExistenceSchemaAsync();
        }

        [Fact]
        public async Task CrmCodeNullException()
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

    }
}
