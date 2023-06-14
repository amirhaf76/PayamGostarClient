using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class DepartmentExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool IsRequired { get; set; }

        public string CrmObjectTypeId { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Department;
    }
}
