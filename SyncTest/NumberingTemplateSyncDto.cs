using PayamGostarClient.ApiClient.Enums;

namespace SyncTest
{
    public class NumberingTemplateSyncDto
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public long InitialSeed { get; set; }
        public long LastNumber { get; set; }
        public bool ResetNumberInNewPrefix { get; set; }
    }

    public class BaseCrmObjectSyncDto
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class CrmObjectSyncDto : BaseCrmObjectSyncDto
    {
        public NumberingTemplateSyncDto NumberingTemplate { get; set; }
    }

    public class GeneralCrmObjectSyncDto
    {
        public Gp_CrmObjectType Type { get; set; }

        public string GroupName { get; set; }

        public string PropertyName { get; set; }

        public string UserKey { get; set; }

    }

    public class GeneralPropertySyncDto
    {
        public GeneralPropertySyncDto()
        {
            PropertyGroup = new PropertyGroupSyncDto();
        }

        public PropertyGroupSyncDto PropertyGroup { get; set; }

        public Gp_CrmObjectType Type { get; set; }
    }

    public class PropertyGroupSyncDto
    {
        public PropertyGroupSyncDto()
        {
            PropertySyncDto = new BaseExtendedPropertySyncDto();
        }

        public string Name { get; set; }

        public int? CountOfColumns { get; set; }

        public bool Expanded { get; set; }

        public BaseExtendedPropertySyncDto PropertySyncDto { get; set; }

    }

    public class BaseExtendedPropertySyncDto
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

    }
}
