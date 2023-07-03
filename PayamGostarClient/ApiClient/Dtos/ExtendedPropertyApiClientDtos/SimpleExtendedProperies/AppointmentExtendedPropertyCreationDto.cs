using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class AppointmentExtendedPropertyCreationDto : CrmItemExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Appointment;
    }
}
