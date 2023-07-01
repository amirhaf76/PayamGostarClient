using PayamGostarClient.ApiClient.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels
{
    public class CrmIdentityModel : BaseCRMModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Identity;

        public int NumberingTemplateId { get; set; }

        public Gp_IdentityType IdentityTypeIndex { get; set; }

        public Gp_IdentityFunction IdentityFunctionIndex { get; set; }

        public Gp_ProfileType ProfileType { get; set; }
    }
}
