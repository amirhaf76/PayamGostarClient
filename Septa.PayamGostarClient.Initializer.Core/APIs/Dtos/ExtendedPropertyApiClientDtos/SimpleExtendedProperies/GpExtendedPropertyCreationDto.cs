﻿using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies
{
    public class GpExtendedPropertyCreationDto : GeneralTypeExtendedPropertyCreationDto
    {
        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.Group;
        public string GpKey { get; set; }
    }

}