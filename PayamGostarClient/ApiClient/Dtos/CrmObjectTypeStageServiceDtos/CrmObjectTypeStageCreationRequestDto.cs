﻿using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeStageServiceDtos
{
    public class CrmObjectTypeStageCreationRequestDto : BaseCrmObjectTypeStageRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

    }
}