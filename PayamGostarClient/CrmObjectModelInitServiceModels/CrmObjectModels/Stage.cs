using System;
using System.Collections.Generic;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels
{
    public class Stage
    {
        public Stage()
        {
            Array.Empty<ResourceValue>();
        }

        internal Guid Id { get; set; }

        internal Guid? ResouceKey { get; set; }


        public ResourceValue[] Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }
    }

    
}
