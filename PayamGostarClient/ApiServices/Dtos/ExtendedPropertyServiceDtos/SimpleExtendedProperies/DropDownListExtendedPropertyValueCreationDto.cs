using System;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos
{
    public class DropDownListExtendedPropertyValueCreationDto
    {
        public Guid PropertyDefinitionId { get; set; }

        public string Value { get; set; }
    }

}
