namespace PayamGostarClient.ApiServices.Dtos
{
    public class PropertyDefinitionGetResultDto
    {
        public System.Guid CrmObjectTypeId { get; set; }

        public string Name { get; set; }
        public string NameResourceKey { get; set; }


        public string Tooltip { get; set; }
        public string TooltipResourceKey { get; set; }

        public string UserKey { get; set; }

        public CrmObjectPropertyGroupGetResultDto Group { get; set; }
    }
}
