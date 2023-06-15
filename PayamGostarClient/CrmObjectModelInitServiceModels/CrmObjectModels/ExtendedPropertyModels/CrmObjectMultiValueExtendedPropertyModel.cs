using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class CrmObjectMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.CrmObjectMultiValue;

        public int CrmObjectTypeIndex { get; set; }

        public string SubTypeId { get; set; }

        public PropertyDefinitionIdWrapperModel[] ShowInGridProps { get; set; }
    }
}
