﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.ProductDtos.Get
{
    public class ProductGroupGetResponseDto
    {
        public Guid Id { get; set; }
        public Guid? ParentGroupId { get; set; }
        public string Name { get; set; }

    }
}
