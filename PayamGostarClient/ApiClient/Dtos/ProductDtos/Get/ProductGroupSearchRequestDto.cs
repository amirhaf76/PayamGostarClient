﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.ProductDtos.Get
{
    public class ProductGroupSearchRequestDto
    {
        public Guid? ParentGroupId { get; set; }

        public string Name { get; set; }

    }
}
