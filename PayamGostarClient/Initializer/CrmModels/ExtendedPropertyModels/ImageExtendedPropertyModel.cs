﻿using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class ImageExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public ImageExtendedPropertyModel()
        {
            SupportedExtensions = new List<string>();
        }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Image;

        public IEnumerable<string> SupportedExtensions { get; set; }

        public int? MaxSize { get; set; }

        public int? ImageWidth { get; set; }

        public int? ImageHeight { get; set; }

        public FileSizeType FileSizeType { get; set; }

    }
}
