using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    /// <summary>
    ///  IsRequired is not used.
    /// </summary>
    public class AppointmentExtendedPropertyModel : CrmObjectExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Appointment;
    }
}
