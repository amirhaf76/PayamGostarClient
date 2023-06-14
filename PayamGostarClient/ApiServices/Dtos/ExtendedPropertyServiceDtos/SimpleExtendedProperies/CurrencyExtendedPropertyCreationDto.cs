using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class CurrencyExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Currency;

        public bool IsRequired { get; set; }

        public bool? IsBalance { get; set; }

        public int? CalculationTypeIndex { get; set; }

    }



}
