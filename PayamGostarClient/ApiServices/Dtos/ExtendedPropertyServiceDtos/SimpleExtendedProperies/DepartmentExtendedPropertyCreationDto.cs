namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class DepartmentExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Department;
    }
}
