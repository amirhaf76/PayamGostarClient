using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies
{
    public class FileMultiValueExtendedPropertyCreationDto : GeneralMultiValueExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.FileMultiValue;

        public int? MaxFileSize { get; set; }

        public int FileSizeTypeIndex { get; set; }

        public IEnumerable<string> FileExtensions { get; set; }
    }

}
