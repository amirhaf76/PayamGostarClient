using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmPaymentModel : CrmBasePaymentModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Payment;
    }



}
