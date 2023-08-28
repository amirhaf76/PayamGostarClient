using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmPaymentModel : CrmBasePaymentModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Payment;
    }



}
