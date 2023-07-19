using Moq;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.Abstractions.Customization.Category;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.Helper.Net;
using System.Net;

namespace PayamGostarClientTest.DataTestModels.CrmFormDataTests
{
    internal static class MockTestExtension
    {
        internal static Mock<IPayamGostarCustomizationApiClient> MockProperties(this Mock<IPayamGostarCustomizationApiClient> mock)
        {
            mock
                .Setup(m => m.ExtendedPropertyApi)
                .Returns(new Mock<IPayamGostarExtendedPropertyApiClient>().Object);
            mock
                .Setup(m => m.PropertyGroupApi)
                .Returns(new Mock<IPayamGostarPropertyGroupApiClient>().Object);
            mock
                .Setup(m => m.NumberingTemplateApi)
                .Returns(new Mock<IPayamGostarNumberingTemplateApiClient>().Object);
            mock
                .Setup(m => m.CrmObjectTypeApi)
                .Returns(new Mock<IPayamGostarCrmObjectTypeApiClient>().Object);
            mock
                .Setup(m => m.CategoryApi)
                .Returns(new Mock<IPayamGostarCategoryApiClient>().Object);

            return mock;
        }

        internal static Mock<IPayamGostarCustomizationApiClient> MockProperties()
        {
            var mock = new Mock<IPayamGostarCustomizationApiClient>();

            mock
                .Setup(m => m.ExtendedPropertyApi)
                .Returns(new Mock<IPayamGostarExtendedPropertyApiClient>().Object);
            mock
                .Setup(m => m.PropertyGroupApi)
                .Returns(new Mock<IPayamGostarPropertyGroupApiClient>().Object);
            mock
                .Setup(m => m.NumberingTemplateApi)
                .Returns(new Mock<IPayamGostarNumberingTemplateApiClient>().Object);
            mock
                .Setup(m => m.CrmObjectTypeApi)
                .Returns(new Mock<IPayamGostarCrmObjectTypeApiClient>().Object);
            mock
                .Setup(m => m.CategoryApi)
                .Returns(new Mock<IPayamGostarCategoryApiClient>().Object);

            return mock;
        }

        internal static Mock<IPayamGostarCustomizationApiClient> MockCrmObjectSearch(this Mock<IPayamGostarCustomizationApiClient> mock)
        {

            return mock;
        }

        public static ApiResponse<T> CreateApiResponse<T>(T obj)
        {
            return new ApiResponse<T>(HttpStatusCode.OK, obj);
        }

    }
}
