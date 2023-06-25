using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.Initializer.CrmModels;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get
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
    public class ImageExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public int Height { get; set; }
        public int Width { get; set; }

    }
    public class SecurityItemExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public bool ShowDeactiveMembersOption { get; set; }
    }
    public class FileExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public IEnumerable<string> Extensions { get; set; }

        public int? MaxSize { get; set; }

        public FileSizeType FileSizeType { get; set; }

    }
    public class ImageFileExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public int Width { get; set; }
        public int Height { get; set; }

    }
    public class AutoNumberExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public long Seed { get; set; }
        public byte Length { get; set; }

    }
    public class ProductListExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public int FractionLength { get; set; }
        public bool ShowAmountColumn { get; set; }
        public bool ShowDiscountColumn { get; set; }
        public bool ShowUnitPriceColumn { get; set; }
        public bool ShowFinalPriceColumn { get; set; }

    }
    public class CurrencyExtendedPropertyExtraConfigDto : ExtendedPropertyExtraConfigDto
    {
        public bool IsBalance { get; set; }
    }



}
