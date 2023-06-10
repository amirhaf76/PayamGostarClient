namespace PayamGostarClient.ApiServices.Dtos
{
    public class CrmObjectPropertyGroupGetResultDto
    {
        public System.Guid CrmObjectTypeId { get; set; }
        public string Name { get; set; }
        public string NameResourceKey { get; set; }
        public int? CountOfColumns { get; set; }
        public bool ExpandForView { get; set; }

    }
}
