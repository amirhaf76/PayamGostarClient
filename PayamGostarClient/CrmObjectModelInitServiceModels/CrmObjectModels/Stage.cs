using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels
{
    public class Stage
    {
        internal Guid Id { get; set; }

        internal Guid ResouceKey { get; set; }


        public ResourceValue[] Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        public bool Enabled { get; set; }

    }
}
