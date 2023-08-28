using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create
{
    public class CrmObjectTypeFormCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public bool IsPublicForm { get; set; }
        public string RedirectAfterSuccessUrl { get; set; }
        public string SubmitMessage { get; set; }
        public bool FlushFormAfterSave { get; set; }
        public bool IsAutoSubject { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public long? StartFrom { get; set; }
        public int? DigitCount { get; set; }

    }
}
