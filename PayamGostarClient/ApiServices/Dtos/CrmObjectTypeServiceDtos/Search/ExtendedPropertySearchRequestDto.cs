using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class ExtendedPropertySearchRequestDto
    {
        public string UserKey { get; set; }

        public IEnumerable<ResourceValueDto> Name { get; set; }

        public IEnumerable<ResourceValueDto> ToolTip { get; set; }
    }


}
