using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search
{
    public class CrmObjectTypeSearchRequestDto
    {
        public int CrmOjectTypeIndex { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int PageSiz { get; set; }

        public int PageNumber { get; set; }

    }


}
