using Newtonsoft.Json;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class ApiResponseExtension
    {
        public static ApiResponse<TOutput> ConvertToApiResponse<TInput, TOutput>(this SwaggerResponse<TInput> swaggerResponse, Func<TInput, TOutput> convertor)
        {
            return new ApiResponse<TOutput>((HttpStatusCode)swaggerResponse.StatusCode, convertor(swaggerResponse.Result));
        }

        public static ApiResponse<TInput> ConvertToApiResponse<TInput>(this SwaggerResponse<TInput> swaggerResponse)
        {
            return new ApiResponse<TInput>((HttpStatusCode)swaggerResponse.StatusCode, swaggerResponse.Result);
        }

        public static ApiResponse ConvertToApiResponse(this SwaggerResponse swaggerResponse)
        {
            return new ApiResponse((HttpStatusCode)swaggerResponse.StatusCode);
        }

        public static ApiResponse<ApiItemContainer<T>> CreateApiResponseWithContainer<T>(this ApiItemContainer<T> apiItemContainer, HttpStatusCode httpStatusCode)
        {
            return new ApiResponse<ApiItemContainer<T>>(httpStatusCode, apiItemContainer);
        }

        public static ApiResponse<ApiItemContainer<T>> CreateApiResponseWithContainer<T>(this ApiItemContainer<T> apiItemContainer, int httpStatusCode)
        {
            return new ApiResponse<ApiItemContainer<T>>((HttpStatusCode)httpStatusCode, apiItemContainer);
        }

        public static Func<Task> WrapInThrowableApiExceptionDto(this Func<Task> func)
        {
            async Task DoElseThrowApiExceptionDto()
            {
                try
                {
                    await func();
                }
                catch (ApiException e)
                {
                    throw CreateApiExceptionDtoFromApiException(e);
                }
            }

            return DoElseThrowApiExceptionDto;
        }

        public static Func<Task<T>> WrapInThrowableApiExceptionDto<T>(this Func<Task<T>> func)
        {
            async Task<T> DoElseThrowApiExceptionDto()
            {
                try
                {
                    return await func();
                }
                catch (ApiException e)
                {
                    throw CreateApiExceptionDtoFromApiException(e);
                }
            }

            return DoElseThrowApiExceptionDto;
        }

        private static ApiExceptionDto CreateApiExceptionDtoFromApiException(ApiException e)
        {
            var headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyValue in e.Headers)
            {
                headers.Add(keyValue.Key, keyValue.Value);
            }

            return new ApiExceptionDto(e)
            {
                StatusCode = (HttpStatusCode)e.StatusCode,
                Response = e.Response,
                Headers = new Dictionary<string, IEnumerable<string>>(headers),
                ApiErrorDto = JsonConvert.DeserializeObject<ApiErrorDto>(e.Response)
            };
        }

    }

    public class ApiExceptionDto : Exception
    {
        public ApiExceptionDto(Exception e) : base(e.Message, e.InnerException)
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; set; }

        public ApiErrorDto ApiErrorDto { get; set; }

    }

    public class ApiErrorDto
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<ApiErrorDetailDto> ErrorDetailDtos { get; set; }
    }

    public class ApiErrorDetailDto
    {
        public int StatusCode { get; set; }

        public string Field { get; set; }

        public string Message { get; set; }

    }
}
