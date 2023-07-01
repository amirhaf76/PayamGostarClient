using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos
{
    public class CrmObjectTypeStageGetResultDto
    {
        public Guid Id { get; set; }
        public Guid CrmObjectTypeId { get; set; }

        public string Name { get; set; }
        public string NameResourceKey { get; set; }

        public string Key { get; set; }
        public int Index { get; set; }

        public bool IsDoneStage { get; set; }
        public bool IsActive { get; set; }

    }
}
