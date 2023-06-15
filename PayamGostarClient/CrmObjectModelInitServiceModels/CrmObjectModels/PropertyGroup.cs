using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels
{
    public class PropertyGroup
    {
        internal int Id { get; set; }

        internal Guid ResouceKey { get; set; }


        public ResourceValue[] Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool Expanded { get; set; }
    }
}
