using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class PositionMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool IsRequired { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Position;
    }


}
