using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.Exceptions;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class LabelExtendedPropertyModel : BaseExtendedPropertyModel
    {
        /// <summary>
         /// Does not work!!! It can not be received by api.
         /// </summary>
        public int CalculationTypeIndex { get => throw new NotSupportedByApiException(); set => throw new NotSupportedByApiException(); }

        public string LabelText { get; set; }

        public int ColorId { get; set; }

        public int ShowTitleTypeIndex { get; set; }

        public string IconName { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Label;
    }
}
