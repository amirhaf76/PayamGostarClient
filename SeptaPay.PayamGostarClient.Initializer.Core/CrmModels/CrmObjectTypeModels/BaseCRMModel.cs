using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Enums;
using System;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public abstract class BaseCRMModel : ICustomizationCrmModel
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


        public bool AssignCustomerNumberOnApprove { get; set; }
        public bool CreateByCustomer { get; set; }
        public bool CustomerCanViewExtendedProps { get; set; }
        public bool IsUnderProcess { get; set; }
        public bool LimitAccessToProcessUsers { get; set; }
        public bool ShowToCustomer { get; set; }
        public bool ViewOnlyToOwner { get; set; }

        public byte SortType { get; set; }

        public int? AllowedDeleteDuration { get; set; }
        public int? AllowedEditDuration { get; set; }

        public string WebhookAddress { get; set; }

        public IEnumerable<WebhookEventType> EventTypes { get; set; }

        public string ContentFilePath { get; set; }


        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.CrmObjectType;
    }
}
