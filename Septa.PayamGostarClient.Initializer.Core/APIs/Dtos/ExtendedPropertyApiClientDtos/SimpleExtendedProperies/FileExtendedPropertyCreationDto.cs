using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class FileExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.File;

        public int? MaxFileSize { get; set; }

        public int FileSizeTypeIndex { get; set; }

        public IEnumerable<string> FileExtensions { get; set; }

    }


}
