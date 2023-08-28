using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get
{
    public class ProductGroupSearchResponseDto
    {
        public Guid Id { get; set; }
        public Guid? ParentGroupId { get; set; }
        public string Name { get; set; }

    }
}
