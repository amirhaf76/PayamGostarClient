using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Threading.Tasks;

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
            CheckFieldMatching(IntendedCrmObject.Prefix, currentCrmObj.Prefix);
            CheckFieldMatching(IntendedCrmObject.Postfix, currentCrmObj.Postfix);
            CheckFieldMatching(IntendedCrmObject.StartFrom, currentCrmObj.StartFrom);
            CheckFieldMatching(IntendedCrmObject.DigitCount, currentCrmObj.DigitCount);

            CheckFieldMatching(IntendedCrmObject.PublicForm?.FlushFormAfterSave, currentCrmObj.PublicForm?.FlushFormAfterSave);
            CheckFieldMatching(IntendedCrmObject.PublicForm?.IsAutoSubject, currentCrmObj.PublicForm?.IsAutoSubject);
            CheckFieldMatching(IntendedCrmObject.PublicForm?.SubmitMessage, currentCrmObj.PublicForm?.SubmitMessage);
            CheckFieldMatching(IntendedCrmObject.PublicForm?.RedirectAfterSuccessUrl, currentCrmObj.PublicForm?.RedirectAfterSuccessUrl);

            return currentCrmObj;
        }
    }

}
