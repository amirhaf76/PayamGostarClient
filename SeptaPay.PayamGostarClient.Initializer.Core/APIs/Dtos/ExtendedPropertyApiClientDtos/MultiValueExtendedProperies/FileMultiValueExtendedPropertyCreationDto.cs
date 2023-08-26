using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies
{
    public class FileMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public FileMultiValueExtendedPropertyCreationDto()
        {
            FileExtensions = new List<string>();
        }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.FileMultiValue;

        public int? MaxFileSize { get; set; }

        public int FileSizeTypeIndex { get; set; }

        public IEnumerable<string> FileExtensions { get; set; }
    }

}
