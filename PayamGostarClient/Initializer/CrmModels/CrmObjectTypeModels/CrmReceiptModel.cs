using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmReceiptModel : CrmBasePaymentModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Receipt;
    }

}
