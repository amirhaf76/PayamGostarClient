using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get
{
    public class ProfileTypeGetResultDto
    {
        public Guid Id { get; set; }

        public int ProfileTypeIndex { get; set; }

        public string ProfileTypeName { get; set; }

        public bool CanAccessToPortal { get; set; }

        public int PointCalendarTypeIndex { get; set; }

        public int PointExpireTypeIndex { get; set; }

        public int PointExpireValue { get; set; }

        public decimal PointReturnValue { get; set; }

    }
}
