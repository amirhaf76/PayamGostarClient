using System;

namespace PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple
{
    public abstract class BaseExtendedPropertyCreationDto : BaseExtendedPropertyDto
    {
        public Guid CrmObjectTypeId { get; set; }
    }




}
