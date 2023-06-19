using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get
{
    public abstract class BaseCrmObjectTypeGetResultDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CrmOjectTypeIndex { get; set; }
        public bool Enabled { get; set; }


        public IEnumerable<PropertyGroupGetResultDto> Groups { get; set; }

        public IEnumerable<StageGetResultDto> Stages { get; set; }

        public IEnumerable<ExtendedPropertyGetResultDto> Properties { get; set; }

    }

}
