using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels
{
    public abstract class BaseCRMModel
    {
        public abstract Gp_CrmObjectType Type { get; }

        public Gp_PreviewType PreviewTypeIndex { get; } = Gp_PreviewType.PDFPreview;

        public string Code { get; set; }

        #region Extera Property
        //public bool? Enabled { get; set; }

        //public bool LimitAccessToProcessUsers { get; set; }

        //public bool ViewOnlyToOwner { get; set; }

        //public bool ShowToCustomer { get; set; }

        //public bool AssignCustomerNumberOnApprove { get; set; }

        //public bool CreateByCustomer { get; set; }

        //public bool CustomerCanViewExtendedProps { get; set; }

        //public string WebhookAddress { get; set; }

        #endregion


        public ResourceValue[] Name { get; set; }

        public ResourceValue[] Description { get; set; }


        public List<BaseExtendedPropertyModel> Properties { get; set; }

        public List<PropertyGroup> PropertyGroups { get; set; }

        public List<Stage> Stages { get; set; }

    }
}
