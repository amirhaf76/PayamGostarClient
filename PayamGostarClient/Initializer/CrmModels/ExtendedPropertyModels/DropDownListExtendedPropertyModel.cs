using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using System;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public class DropDownListExtendedPropertyModel : BaseExtendedPropertyModel
    {
        /// <summary>
        /// Does not work!!! It can not be received by api.
        /// </summary>
        // public int CalculationTypeIndex { get => throw new NotSupportedByApiException(); set => throw new NotSupportedByApiException(); }

        public DropDownListExtendedPropertyModel()
        {
            Values = Array.Empty<DropDownListExtendedPropertyValueModel>();
        }

        public DropDownListExtendedPropertyValueModel[] Values { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.DropDownList;
    }

    public class DropDownListExtendedPropertyValueModel
    {
        internal Guid PropertyDefinitionId { get; set; }

        public string Value { get; set; }

    }
}
