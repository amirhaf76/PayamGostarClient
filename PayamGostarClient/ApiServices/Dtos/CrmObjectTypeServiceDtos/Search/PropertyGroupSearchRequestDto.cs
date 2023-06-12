using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class PropertyGroupSearchRequestDto
    {
        public IEnumerable<ResourceValueDto> Name { get; set; }

        public int CountOfColumns { get; set; }

        public bool Expanded { get; set; }
    }

}
