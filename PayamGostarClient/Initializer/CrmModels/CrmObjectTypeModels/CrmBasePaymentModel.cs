using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
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
