using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos
{
    public class BaseCrmObjectTypeStageRequestDto
    {
        public SystemResourceValueDto Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        // Todo: Gp_OppStageType?  

    }
}
