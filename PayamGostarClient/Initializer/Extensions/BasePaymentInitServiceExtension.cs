using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class BasePaymentInitServiceExtension
    {
        internal static T FillCrmObjectTypeBasePaymentCreateRequestDto<T>(this T target, CrmBasePaymentModel model) where T : CrmObjectTypeBasePaymentCreateRequestDto
        {
            target.ChangeToStatePendingOnUpdate = model.ChangeToStatePendingOnUpdate;
            target.CustomerPaymentType = model.CustomerPaymentType;
            target.NeedApproval = model.NeedApproval;
            target.NeedNumbering = model.NeedNumbering;
            target.Signature = new CrmObjectTypeSignatureFilePathDto { FilePath = model.SignaturePath };

            if (model.NumberingTemplate?.Id.HasValue ?? false)
            {
                target.NumberingTemplateId = model.NumberingTemplate.Id.Value;
            }

            return target.FillBaseCrmObjectTypeCreateRequestDto(model);
        }
    }
}
