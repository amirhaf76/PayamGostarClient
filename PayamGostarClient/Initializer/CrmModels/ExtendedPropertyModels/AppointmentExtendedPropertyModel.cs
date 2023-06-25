using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    /// <summary>
    ///  IsRequired is not used.
    /// </summary>
    public class AppointmentExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Appointment;
    }
}
