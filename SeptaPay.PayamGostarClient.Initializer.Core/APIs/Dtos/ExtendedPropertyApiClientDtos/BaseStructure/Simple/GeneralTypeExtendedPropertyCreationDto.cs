namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple
{
    public abstract class GeneralTypeExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public int? CalculationTypeIndex { get; set; }

        public bool IsRequired { get; set; }
    }



}
