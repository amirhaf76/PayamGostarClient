using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.Initializer.Helpers;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public abstract class BaseExtendedPropertyModel
    {
        public BaseExtendedPropertyModel()
        {
            Name = Array.Empty<ResourceValue>();
            ToolTip = Array.Empty<ResourceValue>();
        }

        public abstract Gp_ExtendedPropertyType Type { get; }

        public string UserKey { get; set; }

        public ResourceValue[] Name { get; set; }
        public ResourceValue[] ToolTip { get; set; }

        public PropertyGroup PropertyGroup { get; set; }

        internal string CrmObjectTypeId { get; set; }

        public bool IsRequired { get; set; }

        public string DefaultValue { get; set; }

    }
}
