using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos
{
    public class StageGetResultDto
    {
        public Guid Id { get; set; }
        public Guid CrmObjectTypeId { get; set; }
        public string Name { get; set; }
        public string NameResourceKey { get; set; }
        public string Key { get; set; }
        public bool IsDoneStage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int Index { get; set; }
    }
}
