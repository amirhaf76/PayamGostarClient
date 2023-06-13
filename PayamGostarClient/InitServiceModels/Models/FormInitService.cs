using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(CrmFormModel crmFormModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(crmFormModel, crmObjectTypeApiService)
        {
        }


        protected override async Task<CrmFormModel> CheckAndModifyCrmPropertiesAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var request = new CrmObjectTypeGetRequestDto
            {

            };

            var gettingCrmObjectResult = await service.GetAsync(request);

            return gettingCrmObjectResult.Result.ToCrmFormModel();
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var request = new CrmObjectTypeFormCreateRequestDto
            {
                Code = IntendedCrmObject.Code,
                Name = new SystemResourceValueDto { ResourceValues = IntendedCrmObject.Name.Select(n => n.ConvertToResourceValueDto()) },
                Description = new SystemResourceValueDto { ResourceValues = IntendedCrmObject.Description.Select(n => n.ConvertToResourceValueDto()) },
                Prefix = IntendedCrmObject.Prefix,
                Postfix = IntendedCrmObject.Postfix,
                StartFrom = IntendedCrmObject.StartFrom,
                DigitCount = IntendedCrmObject.DigitCount,
                PreviewTypeIndex = (int)IntendedCrmObject.PreviewType,

                IsPublicForm = IntendedCrmObject.PublicForm != null,
                SubmitMessage = IntendedCrmObject.PublicForm?.SubmitMessage,
                FlushFormAfterSave = IntendedCrmObject.PublicForm?.FlushFormAfterSave ?? false,
                IsAutoSubject = IntendedCrmObject.PublicForm?.IsAutoSubject ?? false,
                RedirectAfterSuccessUrl = IntendedCrmObject.PublicForm?.RedirectAfterSuccessUrl,
                
            };

            var creationResult = await service.CreateAsync(request);

            return creationResult.Result.Id;
        }
    }

}
