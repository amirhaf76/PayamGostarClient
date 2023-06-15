using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;

namespace PayamGostarClient.InitServiceModels.Models
{
    internal class SearchedExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type { get; }

        public SearchedExtendedPropertyModel(Gp_ExtendedPropertyType type)
        {
            Type = type;
        }
    }
}
