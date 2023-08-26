using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
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

        internal static TTo FillBaseCrmObjectTypeInvoiceCreateRequestVM<TFrom, TTo>(this TTo target, TFrom from)
            where TTo : BaseCrmObjectTypeInvoiceCreateRequestVM
            where TFrom : CrmObjectTypeBaseInvoiceCreateRequestDto
        {
            target.NumberingTemplateId = from.NumberingTemplateId;
            target.Vat = from.Vat;
            target.Toll = from.Toll;
            target.NeedApproval = from.NeedApproval;
            target.NeedNumbering = from.NeedNumbering;
            target.ChangeToStatePendingOnUpdate = from.ChangeToStatePendingOnUpdate;
            target.DisableDecimalCalculation = from.DisableDecimalCalculation;
            target.CanChangeTotalDiscount = from.CanChangeTotalDiscount;
            target.CanChangeTotalTax = from.CanChangeTotalTax;
            target.CanChangeTotalToll = from.CanChangeTotalToll;
            target.CountDecimalDigits = from.CountDecimalDigits;
            target.AllowDuplicateProductIdsInDetails = from.AllowDuplicateProductIdsInDetails;
            target.HasAdditionalCosts = from.HasAdditionalCosts;
            target.AdditionalCostsPlacementTypeIndex = from.AdditionalCostsPlacementTypeIndex;
            target.AdditionalCostsTitle = from.AdditionalCostsTitle;
            target.AdditionalCostIncludedTax = from.AdditionalCostIncludedTax;
            target.AdditionalCostIncludedToll = from.AdditionalCostIncludedToll;
            target.AdditionalCostsTypeIndex = from.AdditionalCostsTypeIndex;
            target.AdditionalCosts = from.AdditionalCosts;
            target.BasePriceFormula = from.BasePriceFormula;
            target.CanMultipleCloneInvoice = from.CanMultipleCloneInvoice;
            target.Signature = from.Signature?.ToVM();

            return target.FillBaseCrmObjectTypeCreateRequestVM(from);
        }
    }
}
