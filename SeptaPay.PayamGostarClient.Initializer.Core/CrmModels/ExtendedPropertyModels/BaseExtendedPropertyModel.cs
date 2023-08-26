using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public abstract class BaseExtendedPropertyModel
    {
        public BaseExtendedPropertyModel()
        {
            Name = Array.Empty<ResourceValue>();
            ToolTip = Array.Empty<ResourceValue>();
        }

        public abstract Gp_ExtendedPropertyType Type { get; }

        internal Guid Id { get; set; }

        internal string CrmObjectTypeId { get; set; }

        internal int PropertyTypeIndex { get; set; }

        public bool DoesBelongToSuperCrmObjectType { get; set; }

        public string UserKey { get; set; }

        public string DefaultValue { get; set; }

        public ResourceValue[] Name { get; set; }

        public ResourceValue[] ToolTip { get; set; }


        public PropertyGroup PropertyGroup { get; set; }

    }
}
