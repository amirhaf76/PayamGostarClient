using System;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos
{
    public class CrmObjectTypeStageCreationRequestDto
    {
        public Guid CrmObjectTypeId { get; set; }

        public bool IsActive { get; set; }

    }
}
