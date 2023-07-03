using PayamGostarClient.ApiClient.Enums;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public abstract class CrmBasePaymentModel : BaseCRMModel
    {
        public int NumberingTemplateId { get; set; }

        public bool NeedApproval { get; set; }

        public bool NeedNumbering { get; set; }

        public bool ChangeToStatePendingOnUpdate { get; set; }

        public IEnumerable<Gp_PaymentType> CustomerPaymentType { get; set; }

        public string SignaturePath { get; set; }
    }
}
