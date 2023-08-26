using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get
{
    public class ProductGroupSearchRequestDto
    {
        public Guid? ParentGroupId { get; set; }

        public string Name { get; set; }

    }
}
