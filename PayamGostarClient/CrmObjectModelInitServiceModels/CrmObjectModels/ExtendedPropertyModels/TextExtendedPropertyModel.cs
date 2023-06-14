using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class TextExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool IsRequired { get; set; }

        public int CalculationTypeIndex { get; set; }

        public bool IsMultiLine { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Text;
    }


}
