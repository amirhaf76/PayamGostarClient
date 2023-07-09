using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class BaseInvoiceInitServiceExtension
    {
        internal static T FillCrmObjectTypeBaseInvoiceCreateRequestDto<T>(this T target, CrmBaseInvoiceModel model) where T : CrmObjectTypeBaseInvoiceCreateRequestDto
        {
            target.AdditionalCostIncludedTax = model.AdditionalCostIncludedTax;
            target.AdditionalCostIncludedToll = model.AdditionalCostIncludedToll;
            target.AdditionalCosts = model.AdditionalCosts;
            target.AdditionalCostsPlacementTypeIndex = (int)model.AdditionalCostsPlacement;
            target.AdditionalCostsTitle = model.AdditionalCostsTitle;
            target.AdditionalCostsTypeIndex = (int)model.InvoiceAdditionalCost;
            target.AllowDuplicateProductIdsInDetails = model.AllowDuplicateProductIdsInDetails;
            target.BasePriceFormula = model.BasePriceFormula;
            target.CanChangeTotalDiscount = model.CanChangeTotalDiscount;
            target.CanChangeTotalTax = model.CanChangeTotalTax;
            target.CanChangeTotalToll = model.CanChangeTotalToll;
            target.CanMultipleCloneInvoice = model.CanMultipleCloneInvoice;
            target.ChangeToStatePendingOnUpdate = model.ChangeToStatePendingOnUpdate;
            target.CountDecimalDigits = model.CountDecimalDigits;
            target.DisableDecimalCalculation = model.DisableDecimalCalculation;
            target.HasAdditionalCosts = model.HasAdditionalCosts;
            target.NeedApproval = model.NeedApproval;
            target.NeedNumbering = model.NeedNumbering;
            target.NumberingTemplateId = model.NumberingTemplateId;
            target.Signature = new CrmObjectTypeSignatureFilePathDto { FilePath = model.SignaturePath };
            target.Toll = model.Toll;
            target.Vat = model.Vat;

            return target.FillBaseCrmObjectTypeCreateRequestDto(model);
        }
    }
}
