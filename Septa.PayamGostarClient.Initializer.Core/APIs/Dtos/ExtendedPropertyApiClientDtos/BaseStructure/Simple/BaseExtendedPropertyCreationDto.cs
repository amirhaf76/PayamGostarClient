using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple
{
    public abstract class BaseExtendedPropertyCreationDto : BaseExtendedPropertyDto
    {
        public Guid CrmObjectTypeId { get; set; }
    }




}
