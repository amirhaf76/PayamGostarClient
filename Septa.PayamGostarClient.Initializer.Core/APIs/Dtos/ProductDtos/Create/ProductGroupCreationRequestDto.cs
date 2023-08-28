using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create
{
    public class ProductGroupCreationRequestDto
    {
        public Guid? ParentGroupId { get; set; }

        public string Name { get; set; }

    }
}
