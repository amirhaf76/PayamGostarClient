using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels
{
    /// <summary>
    ///  IsRequired is not used.
    /// </summary>
    public class AppointmentExtendedPropertyModel : CrmObjectExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Appointment;
    }
}
