using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos
{
    public class CrmObjectTypeStageCreationRequestDto : BaseCrmObjectTypeStageRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

    }
}
