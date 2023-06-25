using System;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple
{
    public abstract class BaseExtendedPropertyCreationDto : BaseExtendedPropertyDto
    {
        public Guid CrmObjectTypeId { get; set; }
    }
    



}
