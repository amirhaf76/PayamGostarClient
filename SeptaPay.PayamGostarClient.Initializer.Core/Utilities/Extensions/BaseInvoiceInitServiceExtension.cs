using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class BaseInvoiceInitServiceExtension
    {
        internal static T FillCrmObjectTypeBaseInvoiceCreateRequestDto<T>(this T target, CrmBaseInvoiceModel model) where T : CrmObjectTypeBaseInvoiceCreateRequestDto
        {
            target.AllowDuplicateProductIdsInDetails = model.AllowDuplicateProductIdsInDetails;
            target.BasePriceFormula = model.TotalPriceFormulaCalculation;
            target.CanChangeTotalDiscount = model.CanChangeTotalDiscount;
            target.CanChangeTotalTax = model.CanChangeTotalTax;
            target.CanChangeTotalToll = model.CanChangeTotalToll;
            target.ChangeToStatePendingOnUpdate = model.ChangeToStatePendingOnUpdate;
            target.CountDecimalDigits = model.CountDecimalDigits;
            target.DisableDecimalCalculation = model.DisableDecimalCalculation;
            target.HasAdditionalCosts = model.HasAdditionalCosts;
            target.NeedApproval = model.NeedApproval;
            target.NeedNumbering = model.NeedNumbering;
            target.Signature = new CrmObjectTypeSignatureFilePathDto { FilePath = model.SignaturePath };
            target.Toll = model.Toll;
            target.Vat = model.Tax;

            if (model.AdditionalCosts != null)
            {
                target.AdditionalCostIncludedTax = model.AdditionalCosts.AdditionalCostIncludedTax;
                target.AdditionalCostIncludedToll = model.AdditionalCosts.AdditionalCostIncludedToll;
                target.AdditionalCosts = model.AdditionalCosts.AdditionalCostsAmount;
                target.AdditionalCostsPlacementTypeIndex = (int)model.AdditionalCosts.AdditionalCostsPlacement;
                target.AdditionalCostsTitle = model.AdditionalCosts.AdditionalCostsTitle;
                target.AdditionalCostsTypeIndex = (int)model.AdditionalCosts.InvoiceAdditionalCost;
            }

            if (model.NumberingTemplate?.Id.HasValue ?? false)
            {
                target.NumberingTemplateId = model.NumberingTemplate.Id.Value;
            }

            return target.FillBaseCrmObjectTypeCreateRequestDto(model);
        }
    }
}
