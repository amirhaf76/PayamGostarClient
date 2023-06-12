using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class CrmObjectTypeSearchRequestDto
    {
        public int CrmOjectTypeIndex { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int PageSiz { get; set; }

        public int PageNumber{ get; set; }

    }


}
