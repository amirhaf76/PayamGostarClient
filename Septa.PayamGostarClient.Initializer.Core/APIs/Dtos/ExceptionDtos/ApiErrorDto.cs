using Septa.PayamGostarClient.Initializer.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExceptionDtos
{
    public class ApiErrorDto
    {
        public ApiErrorDto()
        {
            ErrorDetails = Array.Empty<ApiErrorDetailDto>();
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<ApiErrorDetailDto> ErrorDetails { get; set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"Code: {Code}");
            strBuilder.AppendLine($"Message: {Message}");
            strBuilder.AppendLine($"ErrorDetails:");

            foreach (var error in ErrorDetails)
            {
                strBuilder.AppendLine($"{Help.GetStringsFromProperties(error)}");
            }

            return strBuilder.ToString();
        }
    }
}
