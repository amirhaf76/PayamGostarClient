using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    public class MarketingCampaignExtendedPropertyModel : BaseRequireableExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.MarketingCampaign;
    }

}
