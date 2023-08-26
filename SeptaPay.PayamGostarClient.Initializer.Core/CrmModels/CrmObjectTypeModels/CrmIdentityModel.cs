using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmIdentityModel : BaseCRMModel, INumericalCrmModel
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
