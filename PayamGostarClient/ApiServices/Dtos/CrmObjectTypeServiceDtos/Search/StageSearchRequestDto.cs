using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class StageSearchRequestDto
    {
        public IEnumerable<ResourceValueDto> Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        public bool Enabled { get; set; }

    }

}
