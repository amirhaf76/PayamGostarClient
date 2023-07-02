using PayamGostarClient.ApiClient.Enums;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class AutoNumberExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.AutoNumber;

        public string Prefix { get; set; }

        public string Postfix { get; set; }

        public long Seed { get; set; }

        public byte AutoNumLength { get; set; }

    }
}
