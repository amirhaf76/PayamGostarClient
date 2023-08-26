using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Exceptions;
using SeptaPay.PayamGostarClient.Initializer.Helper.Net;
using SeptaPay.PayamGostarClient.RestApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
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
                    throw e.CreateApiServiceException();
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
                    throw e.CreateApiServiceException();
                }
            }

            return DoElseThrowApiServiceException();
        }

        public static ApiServiceException CreateApiServiceException(this ApiException e)
        {
            var headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyValue in e.Headers)
            {
                headers.Add(keyValue.Key, keyValue.Value);
            }


            return ApiServiceException.Create(
                response: e.Response,
                statusCode: (HttpStatusCode)e.StatusCode,
                headers: new Dictionary<string, IEnumerable<string>>(headers));
        }

        public static ApiServiceException CreateApiServiceException(this ApiException e, string message)
        {
            var headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyValue in e.Headers)
            {
                headers.Add(keyValue.Key, keyValue.Value);
            }
            return ApiServiceException.Create(
                message: message,
                response: e.Response,
                statusCode: (HttpStatusCode)e.StatusCode,
                headers: new Dictionary<string, IEnumerable<string>>(headers));
        }

    }
}
