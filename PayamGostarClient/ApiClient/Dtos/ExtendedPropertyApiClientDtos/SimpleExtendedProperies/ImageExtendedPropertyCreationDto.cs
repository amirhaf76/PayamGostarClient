using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class ImageExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Image;
        public IEnumerable<string> SupportedExtensions { get; set; }

        public int? MaxSize { get; set; }

        public int? ImageWidth { get; set; }

        public int? ImageHeight { get; set; }

        public int FileSizeTypeIndex { get; set; }

    }


}
