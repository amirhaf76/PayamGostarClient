using System.Collections.Generic;

namespace PayamGostarClient.Models
{
    public abstract class BaseCRMModel
    {
        public abstract Gp_CrmObjectType Type { get; }

        public string Code { get; set; }


        public ResourceValue[] Name { get; set; }

        public ResourceValue[] Description { get; set; }


        public List<BaseExtendedPropertyModel> Properties { get; set; }

        public List<PropertyGroup> PropertyGroups { get; set; }

        public List<Stage> Stages { get; set; }

    }
}
