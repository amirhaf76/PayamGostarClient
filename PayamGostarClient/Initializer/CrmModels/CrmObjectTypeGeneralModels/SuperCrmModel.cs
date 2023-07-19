using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class SuperCrmModel : ICustomizationCrmModel
    {
        public SuperCrmModel()
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
