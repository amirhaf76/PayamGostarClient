namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class PositionExtendedPropertyCreationDto : SecurityItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Position;
    }
}
