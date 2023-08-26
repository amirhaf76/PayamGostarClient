using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create
{
    public class CrmObjectTypeIdentityCreationRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public int NumberingTemplateId { get; set; }
        public int IdentityTypeIndex { get; set; }
        public int IdentityFunctionIndex { get; set; }
        public Guid ProfileTypeId { get; set; }

    }
}
