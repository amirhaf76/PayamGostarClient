using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple
{
    public class BaseExtendedPropertyDto
    {
        public SystemResourceValueDto Name { get; set; }

        public SystemResourceValueDto ToolTip { get; set; }

        public int PropertyGroupId { get; set; }

        public string DefaultValue { get; set; }

        public string UserKey { get; set; }

    }



}
