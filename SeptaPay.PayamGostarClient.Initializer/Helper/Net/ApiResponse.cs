﻿using System.Net;
using System.Net.Http;

namespace SeptaPay.PayamGostarClient.Initializer.Helper.Net
{
    public class ApiResponse<T> : ApiResponse
    {
        public T Result { get; private set; }

        public ApiResponse(HttpResponseMessage responseMessage, T obj) : this(responseMessage.StatusCode, obj)
        {
        }

        public ApiResponse(HttpStatusCode httpStatusCode, T obj) : base(httpStatusCode)
        {
            Result = obj;
        }

        public ApiResponse(HttpStatusCode httpStatusCode, ApiErrorResponseDto error) : base(httpStatusCode, error)
        {
        }

    }

    public class ApiResponse
    {
        private ApiErrorResponseDto _error;

        public HttpStatusCode StatusCode { get; protected set; }

        public bool IsSuccessfull { get => Error == null; }

        public ApiErrorResponseDto Error
        {
            get
            {
                return _error?.Clone() as ApiErrorResponseDto;
            }

            protected set
            {
                _error = value;
            }
        }

        public ApiResponse(HttpResponseMessage responseMessage) : this(responseMessage.StatusCode)
        {
        }

        public ApiResponse(HttpResponseMessage responseMessage, ApiErrorResponseDto error) : this(responseMessage.StatusCode, error)
        {
        }

        public ApiResponse(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }

        public ApiResponse(HttpStatusCode httpStatusCode, ApiErrorResponseDto error) : this(httpStatusCode)
        {
            Error = error;
        }
    }

}
