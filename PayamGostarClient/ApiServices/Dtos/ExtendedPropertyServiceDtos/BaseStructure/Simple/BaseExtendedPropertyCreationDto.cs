using System;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple
{
    public abstract class BaseExtendedPropertyCreationDto : BaseExtendedPropertyDto
    {
        public Guid CrmObjectTypeId { get; set; }
    }
    



}
