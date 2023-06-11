using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class BaseCrmModelDto
    {
        public int Type { get; set; }

        public string Code { get; set; }


        public IEnumerable<ResourceValueDto> Name { get; set; }

        public IEnumerable<ResourceValueDto> Description { get; set; }


        public IEnumerable<BaseExtendedPropertyModelDto> Properties { get; set; }

        public IEnumerable<PropertyGroupDto> PropertyGroups { get; set; }

        public IEnumerable<StageDto> Stages { get; set; }
    }

    public class ResourceValueDto
    {
        public string Value { get; set; }

        public string LanguageCulture { get; set; }
    }

    public class BaseExtendedPropertyModelDto
    {
        public string UserKey { get; set; }

        public IEnumerable<ResourceValueDto> Name { get; set; }

        public IEnumerable<ResourceValueDto> ToolTip { get; set; }
    }

    public class PropertyGroupDto
    {
        public IEnumerable<ResourceValueDto> Name { get; set; }

        public int CountOfColumns { get; set; }

        public bool Expanded { get; set; }
    }

    public class StageDto
    {
        public IEnumerable<ResourceValueDto> Name { get; set; }

        public string Key { get; set; }

        public bool IsDoneStage { get; set; }

        public bool Enabled { get; set; }

    }

}
