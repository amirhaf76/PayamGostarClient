namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple
{
    public abstract class GeneralTypeExtendedPropertyCreationDto : BaseExtendedPropertyCreationDto
    {
        public int? CalculationTypeIndex { get; set; }

        public bool IsRequired { get; set; }
    }



}
