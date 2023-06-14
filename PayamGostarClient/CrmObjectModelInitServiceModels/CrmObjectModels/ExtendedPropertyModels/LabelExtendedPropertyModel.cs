using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class LabelExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public int CalculationTypeIndex { get; set; }

        public string CrmObjectTypeId { get; set; }

        public string LabelText { get; set; }

        public int ColorId { get; set; }

        public int ShowTitleTypeIndex { get; set; }

        public string IconName { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Label;
    }
}
