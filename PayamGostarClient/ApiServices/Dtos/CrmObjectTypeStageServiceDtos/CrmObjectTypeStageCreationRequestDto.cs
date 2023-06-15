using System;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos
{
    public class CrmObjectTypeStageCreationRequestDto : BaseCrmObjectTypeStageRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public bool Enabled { get; set; }

    }
}
