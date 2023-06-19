namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.SimpleExtendedProperies
{
    public class DepartmentExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Department;
    }
}
