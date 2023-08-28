namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos
{
    public class BaseCrmObjectTypeStageRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        // Todo: Gp_OppStageType?  

    }
}
