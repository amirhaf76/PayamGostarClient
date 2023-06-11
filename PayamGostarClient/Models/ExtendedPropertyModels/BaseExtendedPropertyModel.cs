namespace PayamGostarClient.Models
{
    public abstract class BaseExtendedPropertyModel
    {
        public string UserKey { get; set; }

        public ResourceValue[] Name { get; set; }
        public ResourceValue[] ToolTip { get; set; }

        public PropertyGroup PropertyGroup { get; set; }
    }
}
