using System;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Helper.Net
{
    public class ApiErrorResponseDto : ICloneable
    {
        public ApiErrorResponseDto()
        {

        }

        public ApiErrorResponseDto(ApiErrorResponseDto apiErrorResponseDto)
        {
            Data = apiErrorResponseDto.Data;
            Message = apiErrorResponseDto.Message;
            Code = apiErrorResponseDto.Code;
            Headers = new Dictionary<string, IEnumerable<string>>(apiErrorResponseDto.Headers);
        }

        public IDictionary<string, IEnumerable<string>> Headers { get; private set; }

        public object Data { get; set; }

        public string Message { get; set; }

        public int? Code { get; set; }

        public object Clone()
        {
            return new ApiErrorResponseDto(this);
        }
    }

}
