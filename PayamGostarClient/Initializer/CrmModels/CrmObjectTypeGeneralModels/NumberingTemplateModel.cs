using PayamGostarClient.Initializer.Abstractions;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class NumberingTemplateModel : ICustomizationCrmModel
    {
        internal int? Id { get; set; }

        public string Name { get; set; }

        public string Prefix { get; set; }

        public long InitialSeed { get; set; }

        public long LastNumber { get; set; }

        public bool? ResetNumberInNewPrefix { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.NumberingTemplate;
    }




}
