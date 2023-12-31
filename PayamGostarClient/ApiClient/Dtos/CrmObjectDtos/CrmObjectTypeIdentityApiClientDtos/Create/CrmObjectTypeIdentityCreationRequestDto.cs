﻿using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create
{
    public class CrmObjectTypeIdentityCreationRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public int NumberingTemplateId { get; set; }
        public int IdentityTypeIndex { get; set; }
        public int IdentityFunctionIndex { get; set; }
        public Guid ProfileTypeId { get; set; }

    }
}
