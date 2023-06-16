using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class DepartmentExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Department;
    }
}
