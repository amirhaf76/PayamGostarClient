﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Search
{
    public class NumberingTemplateSearchRequestDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public long? InitialSeed { get; set; }
        public long? LastNumber { get; set; }
        public string LastPrefix { get; set; }

    }
}
