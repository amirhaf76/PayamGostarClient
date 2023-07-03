using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create
{
    public class NumberingTemplateCreationRequestDto
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public long InitialSeed { get; set; }
        public long LastNumber { get; set; }
        public bool? ResetNumberInNewPrefix { get; set; }
    }
}
