using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos
{
    public class CrmObjectTypeStageCreationRequestDto : BaseCrmObjectTypeStageRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

    }
}
