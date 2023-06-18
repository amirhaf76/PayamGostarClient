using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class FileExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public FileExtendedPropertyModel()
        {
            FileExtensions = Array.Empty<string>();
        }
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.File;

        public int? MaxFileSize { get; set; }

        public int FileSizeTypeIndex { get; set; }

        public string[] FileExtensions { get; set; }

    }
}
