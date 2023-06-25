using Newtonsoft.Json;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Dtos.ExceptionDtos;
using PayamGostarClient.ApiClient.Exceptions;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Extension
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

        public static Task<SwaggerResponse<T>> WrapInThrowableApiServiceExceptionAndInvoke<T>(this Task<SwaggerResponse<T>> task)
        {
            async Task<SwaggerResponse<T>> DoElseThrowApiServiceException()
            {
                try
                {
                    var taskResult = await task;

                    return taskResult;
                }
                catch (ApiException e)
                {
                    throw CreateApiExceptionDtoFromApiException(e);
                }
            }

            return DoElseThrowApiServiceException();
        }

        public static Task<SwaggerResponse> WrapInThrowableApiServiceExceptionAndInvoke(this Task<SwaggerResponse> task)
        {
            async Task<SwaggerResponse> DoElseThrowApiServiceException()
            {
                try
                {
                    var taskResult = await task;

                    return taskResult;
                }
                catch (ApiException e)
                {
                    throw CreateApiExceptionDtoFromApiException(e);
                }
            }

            return DoElseThrowApiServiceException();
        }

        public static ApiServiceException CreateApiExceptionDtoFromApiException(ApiException e)
        {
            var headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyValue in e.Headers)
            {
                headers.Add(keyValue.Key, keyValue.Value);
            }

            return new ApiServiceException(e)
            {
                StatusCode = (HttpStatusCode)e.StatusCode,
                Response = e.Response,
                Headers = new Dictionary<string, IEnumerable<string>>(headers),
                ApiError = JsonConvert.DeserializeObject<ApiErrorDto>(e.Response)
            };
        }

        public static ApiServiceException CreateApiExceptionDtoFromApiException(string message, ApiException e)
        {
            var headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyValue in e.Headers)
            {
                headers.Add(keyValue.Key, keyValue.Value);
            }

            return new ApiServiceException(message, e)
            {
                StatusCode = (HttpStatusCode)e.StatusCode,
                Response = e.Response,
                Headers = new Dictionary<string, IEnumerable<string>>(headers),
                ApiError = JsonConvert.DeserializeObject<ApiErrorDto>(e.Response)
            };
        }

    }
}
