namespace PayamGostarClient.ApiServices.Dtos
{
    public class ExtendedPropertyGetResultDto
    {
        public int PropertyDisplayTypeIndex { get;  set; }

        public int? PropertyGroupId { get; set; }

        public string Name { get; set; }

        public string NameResourceKey { get; set; }


        public string Tooltip { get; set; }

        public string TooltipResourceKey { get; set; }

        public string UserKey { get; set; }

        public PropertyGroupGetResultDto Group { get; set; }
    }
}
