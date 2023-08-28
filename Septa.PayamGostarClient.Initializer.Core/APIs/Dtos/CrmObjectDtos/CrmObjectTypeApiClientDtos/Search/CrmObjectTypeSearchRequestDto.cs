namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search
{
    public class CrmObjectTypeSearchRequestDto
    {
        public int? CrmOjectTypeIndex { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? PageSiz { get; set; }

        public int? PageNumber { get; set; }

        public bool IsAbstract { get; set; }

    }


}
