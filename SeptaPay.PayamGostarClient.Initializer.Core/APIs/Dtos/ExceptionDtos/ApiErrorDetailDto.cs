namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExceptionDtos
{
    public class ApiErrorDetailDto
    {
        public int StatusCode { get; set; }

        public string Field { get; set; }

        public string Message { get; set; }

    }
}
