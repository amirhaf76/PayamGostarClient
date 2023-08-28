using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public abstract class CrmBasePaymentModel : BaseCRMModel, INumericalCrmModel
    {
        public CrmBasePaymentModel()
        {
            CustomerPaymentType = new List<Gp_PaymentType>();
            NumberingTemplate = new NumberingTemplateModel();
        }

        public NumberingTemplateModel NumberingTemplate { get; set; }

        public bool NeedApproval { get; set; }

        public bool NeedNumbering { get; set; }

        public bool ChangeToStatePendingOnUpdate { get; set; }

        public IEnumerable<Gp_PaymentType> CustomerPaymentType { get; set; }

        public string SignaturePath { get; set; }
    }
}
