using PayamGostarClient.ApiProvider;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class CrmObjectTypeGetResultDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CrmOjectTypeIndex { get; set; }
        public IEnumerable<CrmObjectPropertyGroupGetResultDto> Groups { get; set; }
        public IEnumerable<CrmObjectTypeStageGetResultDto> Stages { get; set; }
        public IEnumerable<PropertyDefinitionGetResultDto> Properties { get; set; }

    }
}
