using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.Exceptions;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class TextExtendedPropertyModel : BaseExtendedPropertyModel
    {
        /// <summary>
        /// Does not work!!! It can not be received by api.
        /// </summary>
        public int CalculationTypeIndex { get => throw new NotSupportedByApiException(); set => throw new NotSupportedByApiException(); }

        /// <summary>
        /// Does not work!!! It can not be received by api.
        /// </summary>
        public bool IsMultiLine { get => throw new NotSupportedByApiException(); set => throw new NotSupportedByApiException(); }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Text;
    }


}
