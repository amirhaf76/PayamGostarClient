﻿using System;

namespace PayamGostarClient.ApiClient.Dtos.CategoryDtos.Create
{
    public class CategoryCreationResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserKey { get; set; }
        public bool AddedByUser { get; set; }
        public Guid? OwnerUserId { get; set; }
        public Guid? ParentId { get; set; }

    }
}
