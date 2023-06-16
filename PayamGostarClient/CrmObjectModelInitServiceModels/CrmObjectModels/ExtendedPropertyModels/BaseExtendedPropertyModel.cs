using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public abstract class BaseExtendedPropertyModel
    {
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
