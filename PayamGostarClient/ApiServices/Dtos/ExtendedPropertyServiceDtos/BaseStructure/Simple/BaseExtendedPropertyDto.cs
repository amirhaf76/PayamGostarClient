﻿using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;

namespace PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple
{
    public abstract class BaseExtendedPropertyDto
    {
        public abstract ExtendedPropertyType Type { get; }

        public SystemResourceValueDto Name { get; set; }

        public SystemResourceValueDto ToolTip { get; set; }

        public int PropertyGroupId { get; set; }

        public string DefaultValue { get; set; }

        public string UserKey { get; set; }

    }



}
