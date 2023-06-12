using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.InitServiceModels.Models
{
    internal class SearchedCrmObjectModel : BaseCRMModel
    {
        public Guid Id { get; set; }

        public override Gp_CrmObjectType Type { get; }

        public SearchedCrmObjectModel(Gp_CrmObjectType type)
        {
            Type = type;
        }
    }

    internal class SearchedExtendedPropertyModel : BaseExtendedPropertyModel
    {

    }
}
