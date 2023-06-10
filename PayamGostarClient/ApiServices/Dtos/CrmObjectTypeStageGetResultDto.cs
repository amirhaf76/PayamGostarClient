namespace PayamGostarClient.ApiServices.Dtos
{
    public class CrmObjectTypeStageGetResultDto
    {
        public System.Guid CrmObjectTypeId { get; set; }
        public string Name { get; set; }
        public string NameResourceKey { get; set; }
        public string Key { get; set; }
        public bool IsDoneStage { get; set; }
        public bool IsActive { get; set; }

    }
}
