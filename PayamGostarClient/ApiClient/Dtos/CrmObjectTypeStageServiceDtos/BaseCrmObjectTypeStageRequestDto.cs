using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeStageServiceDtos
{
    public class BaseCrmObjectTypeStageRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        // Todo: Gp_OppStageType?  

    }
}
