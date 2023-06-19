namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get
{
    public class PropertyGroupGetResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameResourceKey { get; set; }

        public int? CountOfColumns { get; set; }

        public bool ExpandForView { get; set; }

    }
}
