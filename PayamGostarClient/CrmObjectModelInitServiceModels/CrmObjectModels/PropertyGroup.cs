﻿using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels
{
    public class PropertyGroup
    {
        public PropertyGroup()
        {
            Name = Array.Empty<ResourceValue>();
        }

        internal int Id { get; set; }

        public ResourceValue[] Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool Expanded { get; set; }
    }
}
