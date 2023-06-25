namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get
{
    public class StageGetResultDto
    {
        public string Name { get; set; }
        public string NameResourceKey { get; set; }
        public string Key { get; set; }
        public bool IsDoneStage { get; set; }
        public bool IsActive { get; set; }
        public int Index { get; set; }
    }
}
