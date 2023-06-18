using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Models
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(CrmFormModel crmFormModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(crmFormModel, crmObjectTypeApiService)
        {
        }


        protected override async Task<CrmFormModel> GetCrmObjectTypeAsync(Guid id)
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var request = new CrmObjectTypeGetRequestDto
            {
                Id = id,
            };

            var gettingCrmObjectResult = await service.GetAsync(request);

            return gettingCrmObjectResult.Result.ToModel();
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var creationResult = await service.CreateAsync(IntendedCrmObject.ToDto());

            return creationResult.Result.Id;
        }

        protected override CrmFormModel CheckCrmObjectMatching(CrmFormModel currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.Prefix, currentCrmObj.Prefix, "FormCrmObj:Prefix -> ");
            CheckFieldMatching(IntendedCrmObject.Postfix, currentCrmObj.Postfix, "FormCrmObj:Postfix -> ");
            CheckFieldMatching(IntendedCrmObject.StartFrom, currentCrmObj.StartFrom, "FormCrmObj:StartFrom -> ");
            CheckFieldMatching(IntendedCrmObject.DigitCount, currentCrmObj.DigitCount, "FormCrmObj:DigitCount -> ");

            CheckFieldMatching(IntendedCrmObject.PublicForm?.FlushFormAfterSave, currentCrmObj.PublicForm?.FlushFormAfterSave, "FormCrmObj:PublicForm:FlushFormAfterSave -> ");
            CheckFieldMatching(IntendedCrmObject.PublicForm?.IsAutoSubject, currentCrmObj.PublicForm?.IsAutoSubject, "FormCrmObj:PublicForm:IsAutoSubject -> ");
            CheckFieldMatching(IntendedCrmObject.PublicForm?.SubmitMessage, currentCrmObj.PublicForm?.SubmitMessage, "FormCrmObj:PublicForm:SubmitMessage -> ");
            CheckFieldMatching(IntendedCrmObject.PublicForm?.RedirectAfterSuccessUrl, currentCrmObj.PublicForm?.RedirectAfterSuccessUrl, "FormCrmObj:PublicForm:RedirectAfterSuccessUrl -> ");

            return currentCrmObj;
        }
    }

}
