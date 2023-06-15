using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class DropDownListExtendedPropertyModel : BaseExtendedPropertyModel
    {
        // public bool IsRequired { get; set; }

        // public int CalculationTypeIndex { get; set; }

        public DropDownListExtendedPropertyValueModel[] Values { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.DropDownList;
    }

    public class DropDownListExtendedPropertyValueModel
    {
        internal Guid PropertyDefinitionId { get; set; }

        public string Value { get; set; }

    }
}
