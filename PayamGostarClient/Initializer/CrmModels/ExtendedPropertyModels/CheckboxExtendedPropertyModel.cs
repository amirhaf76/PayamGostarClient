using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class CheckboxExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Checkbox;
    }
}
