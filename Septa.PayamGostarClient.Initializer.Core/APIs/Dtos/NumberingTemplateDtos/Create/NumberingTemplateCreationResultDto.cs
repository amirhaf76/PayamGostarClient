namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create
{
    public class NumberingTemplateCreationResultDto
    {
        public int NumberingTemplateId { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string InitialSeed { get; set; }
        public string LastNumber { get; set; }
        public bool ResetNumberInNewPrefix { get; set; }
        public bool TemplatedIsUsed { get; set; }

    }
}
