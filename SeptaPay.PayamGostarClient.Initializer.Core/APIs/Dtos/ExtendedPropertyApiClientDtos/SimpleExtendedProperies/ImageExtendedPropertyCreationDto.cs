using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class ImageExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public ImageExtendedPropertyCreationDto()
        {
            SupportedExtensions = new List<string>();
        }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Image;

        public IEnumerable<string> SupportedExtensions { get; set; }

        public int? MaxSize { get; set; }

        public int? ImageWidth { get; set; }

        public int? ImageHeight { get; set; }

        public int FileSizeTypeIndex { get; set; }

    }


}
