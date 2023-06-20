using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels
{
    public abstract class BaseCRMModel
    {
        public BaseCRMModel()
        {
            Properties = new List<BaseExtendedPropertyModel>();
            PropertyGroups = new List<PropertyGroup>();
            Stages = new List<Stage>();
            Name = Array.Empty<ResourceValue>();
            Description = Array.Empty<ResourceValue>();
        }
        public abstract Gp_CrmObjectType Type { get; }

        public Gp_PreviewType PreviewTypeIndex { get; set; } = Gp_PreviewType.WordPreview;

        public string Code { get; set; }

        public bool? Enabled { get; set; } = true;
   

        public ResourceValue[] Name { get; set; }

        public ResourceValue[] Description { get; set; }


        public List<BaseExtendedPropertyModel> Properties { get; set; }

        public List<PropertyGroup> PropertyGroups { get; set; }

        public List<Stage> Stages { get; set; }

    }
}
