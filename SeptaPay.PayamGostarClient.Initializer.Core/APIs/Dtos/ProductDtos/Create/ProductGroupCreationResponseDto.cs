using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create
{
    public class ProductGroupCreationResponseDto
    {
        public Guid Id { get; set; }
        public Guid? ParentGroupId { get; set; }
        public string Name { get; set; }

    }
}
