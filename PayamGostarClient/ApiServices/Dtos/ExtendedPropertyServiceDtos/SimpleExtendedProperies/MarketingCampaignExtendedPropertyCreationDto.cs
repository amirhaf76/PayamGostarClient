using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class MarketingCampaignExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.MarketingCampaign;
        public bool IsRequired { get; set; }
    }
     

}
