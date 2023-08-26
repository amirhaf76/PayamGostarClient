using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels
{
    public class Stage
    {
        public Stage()
        {
            Array.Empty<ResourceValue>();
        }

        internal Guid Id { get; set; }

        internal Guid CrmObjectTypeId { get; set; }

        internal Guid? ResouceKey { get; set; }

        internal int Index { get; set; }

        internal bool IsDeleted { get; set; }


        public ResourceValue[] Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        public bool Enabled { get; set; }

    }


}
