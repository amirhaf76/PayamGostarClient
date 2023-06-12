using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class CrmObjectTypeSearchResultDto : BaseCrmObjectTypeGetResultDto
    {
        public System.Guid Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Code { get; set; }
        //public int CrmOjectTypeIndex { get; set; }

        //public IEnumerable<PropertyGroupGetResultDto> Groups { get; set; }
        //public IEnumerable<StageGetResultDto> Stages { get; set; }
        //public IEnumerable<ExtendedPropertyGetResultDto> Properties { get; set; }

    }
}
