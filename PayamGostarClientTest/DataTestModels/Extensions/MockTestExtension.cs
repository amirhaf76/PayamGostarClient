using Moq;
using PayamGostarClient.Helper.Net;
using System.Net;
using System.Threading.Tasks;

namespace PayamGostarClientTest.DataTestModels.Extensions
{
    internal static class MockTestExtension
    {
        public static ApiResponse<T> CreateApiResponse<T>(T obj)
        {
            return new ApiResponse<T>(HttpStatusCode.OK, obj);
        }

        internal static Moq.Language.Flow.IReturnsResult<TMock> ReturnsApiResponseAsync<TMock, TResult>(this Moq.Language.IReturns<TMock, Task<ApiResponse<TResult>>> mock, TResult value) where TMock : class
        {
            return mock.ReturnsAsync(() => new ApiResponse<TResult>(HttpStatusCode.OK, value));
        }

    }
}
