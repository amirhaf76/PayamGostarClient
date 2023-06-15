using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos
{
    public class ExtendedPropertyGetResultDto
    {
        public Guid Id { get; set; }

        public Guid CrmObjectTypeId { get; set; }

        public string DefaultValue { get; set; }

        public bool IsRequired { get; set; }



        public int PropertyDisplayTypeIndex { get; set; }

        public int? PropertyGroupId { get; set; }

        public string Name { get; set; }

        public string NameResourceKey { get; set; }


        public string Tooltip { get; set; }

        public string TooltipResourceKey { get; set; }

        public string UserKey { get; set; }

        public PropertyGroupGetResultDto Group { get; set; }


        public ExtendedPropertyExtraConfigDto ExtraConfig { get; set; }
    }

    public abstract class ExtendedPropertyExtraConfigDto
    {

    }

    public class CrmObjectMultiValueExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public IEnumerable<Guid> VisibleProperties { get; set; }
        public Gp_CrmObjectType CrmObjectType { get; set; }
        public Guid? SubTypeId { get; set; }

    }
    public class LabelExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public string LabelText { get; set; }
        public string ColorName { get; set; }
        public int? ColorIndex { get; set; }
        public bool ShowTitle { get; set; }
        public string IconName { get; set; }

    }
    public class NumericExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public int DecimalDigits { get; set; }
        public int? MinDigits { get; set; }
        public int? MaxDigits { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public bool ShowColumn { get; set; }

    }
    public class CrmObjectReferencedTypeExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public Guid? CrmObjectTypeId { get; set; }
        public bool? PreventSettingContainerCrmobjectAsParent { get; set; }

    }
    public class TextInvoiceDetailExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public bool ShowColumn { get; set; }
    }

}
