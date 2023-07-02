using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeInvoiceApiClientExtension
    {
        internal static CrmObjectTypeInvoiceCreateRequestVM ToVM(this CrmObjectTypeInvoiceCreateRequestDto dto)
        {
            return new CrmObjectTypeInvoiceCreateRequestVM
            {
                AutoGenerateInventoryTransaction = dto.AutoGenerateInventoryTransaction,
                AutoTransactionTypeId = dto.AutoTransactionTypeId,

            }.FillBaseCrmObjectTypeInvoiceCreateRequestVM(dto);
        }

        internal static AdditionalCostsPlacementTypeGetResultDto ToDto(this AdditionalCostsPlacementTypeGetResultVM dto)
        {
            return new AdditionalCostsPlacementTypeGetResultDto
            {
                Index = dto.Index,
                Name = dto.Name,
            };
        }

        internal static InvoiceAdditionalCostTypeGetResultDto ToDto(this InvoiceAdditionalCostTypeGetResultVM vm)
        {
            return new InvoiceAdditionalCostTypeGetResultDto
            {
                Index = vm.Index,
                Name = vm.Name,
            };
        }

        internal static TTo FillBaseCrmObjectTypeInvoiceCreateRequestVM<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeInvoiceCreateRequestVM
            where TFrom : BaseCrmObjectTypeInvoiceCreateRequestDto
        {
            to.NumberingTemplateId = from.NumberingTemplateId;
            to.Vat = from.Vat;
            to.Toll = from.Toll;
            to.NeedApproval = from.NeedApproval;
            to.NeedNumbering = from.NeedNumbering;
            to.ChangeToStatePendingOnUpdate = from.ChangeToStatePendingOnUpdate;
            to.DisableDecimalCalculation = from.DisableDecimalCalculation;
            to.CanChangeTotalDiscount = from.CanChangeTotalDiscount;
            to.CanChangeTotalTax = from.CanChangeTotalTax;
            to.CanChangeTotalToll = from.CanChangeTotalToll;
            to.CountDecimalDigits = from.CountDecimalDigits;
            to.AllowDuplicateProductIdsInDetails = from.AllowDuplicateProductIdsInDetails;
            to.HasAdditionalCosts = from.HasAdditionalCosts;
            to.AdditionalCostsPlacementTypeIndex = from.AdditionalCostsPlacementTypeIndex;
            to.AdditionalCostsTitle = from.AdditionalCostsTitle;
            to.AdditionalCostIncludedTax = from.AdditionalCostIncludedTax;
            to.AdditionalCostIncludedToll = from.AdditionalCostIncludedToll;
            to.AdditionalCostsTypeIndex = from.AdditionalCostsTypeIndex;
            to.AdditionalCosts = from.AdditionalCosts;
            to.BasePriceFormula = from.BasePriceFormula;
            to.CanMultipleCloneInvoice = from.CanMultipleCloneInvoice;
            to.Signature = from.Signature.ToVM();

            return to.FillBaseCrmObjectTypeCreateRequestVM(from);
        } 
    }
}
