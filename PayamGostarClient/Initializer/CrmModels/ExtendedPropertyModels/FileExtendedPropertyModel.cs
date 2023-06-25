using PayamGostarClient.ApiClient.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class FileExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public FileExtendedPropertyModel()
        {
            Extensions = Array.Empty<string>();
        }
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.File;

        public int? MaxFileSize { get; set; }

        public FileSizeType FileSizeTypeIndex { get; set; }

        public string[] Extensions { get; set; }

    }
}
