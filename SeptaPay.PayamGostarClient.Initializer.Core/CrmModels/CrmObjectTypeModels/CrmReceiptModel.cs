using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmReceiptModel : CrmBasePaymentModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Receipt;
    }

}
