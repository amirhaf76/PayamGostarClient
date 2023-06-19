using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExceptionDtos
{
    public class ApiErrorDto
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<ApiErrorDetailDto> ErrorDetails { get; set; }
    }
}
