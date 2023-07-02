using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class FileExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.File;

        public int? MaxFileSize { get; set; }

        public int FileSizeTypeIndex { get; set; }

        public IEnumerable<string> FileExtensions { get; set; }

    }


}
