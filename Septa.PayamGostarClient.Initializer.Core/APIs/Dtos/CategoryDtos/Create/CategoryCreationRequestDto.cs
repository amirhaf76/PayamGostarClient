using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create
{
    public class CategoryCreationRequestDto
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

        public bool AddedByUser { get; set; }

        public Guid? OwnerUserId { get; set; }

        public Guid? ParentId { get; set; }

    }
}
