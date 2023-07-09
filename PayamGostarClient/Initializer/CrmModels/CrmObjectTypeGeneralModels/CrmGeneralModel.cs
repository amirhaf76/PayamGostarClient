using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class CrmGeneralModel : ICustomizationCrmModel
    {
        public CrmGeneralModel()
        {
            Properties = new List<BaseExtendedPropertyModel>();
            PropertyGroups = new List<PropertyGroup>();
        }

        public List<BaseExtendedPropertyModel> Properties { get; set; }

        public List<PropertyGroup> PropertyGroups { get; set; }

        public Gp_CrmObjectType Type { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.GeneralCrmObjectType;
    }




}
