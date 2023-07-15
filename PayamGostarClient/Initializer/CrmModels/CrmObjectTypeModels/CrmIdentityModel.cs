using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmIdentityModel : BaseCRMModel
    {
        public CrmIdentityModel()
        {
            NumberingTemplate = new NumberingTemplateModel();
        }

        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Identity;

        public NumberingTemplateModel NumberingTemplate { get; set; }

        public Gp_IdentityType IdentityTypeIndex { get; set; }

        public Gp_IdentityFunction IdentityFunctionIndex { get; set; }

        public Gp_ProfileType ProfileType { get; set; }
    }
}
