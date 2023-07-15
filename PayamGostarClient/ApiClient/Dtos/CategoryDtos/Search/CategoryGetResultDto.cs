using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.CategoryDtos.Search
{
    public class CategoryGetResultDto
    {
        public System.Guid Id { get; set; }

        public System.Guid? ParentId { get; set; }

        public string Name { get; set; }

    }
}
