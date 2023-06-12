using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos
{
    public class CrmObjectTypeFormGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public string RedirectAfterSuccessUrl { get; set; }

        public string SubmitMessage { get; set; }

        public bool FlushFormAfterSave { get; set; }

        public bool IsAutoSubject { get; set; }

        public string Prefix { get; set; }

        public string Postfix { get; set; }

        public long? StartFrom { get; set; }

        public int? DigitCount { get; set; }

        public bool IsPublicForm { get; set; }
    }
}
