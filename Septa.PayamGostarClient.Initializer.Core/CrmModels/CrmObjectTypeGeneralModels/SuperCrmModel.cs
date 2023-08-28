using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using Septa.PayamGostarClient.Initializer.Core.Enums;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels
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
