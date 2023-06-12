using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
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
                
            };

            var creationResult = await service.CreateAsync(request);

            return creationResult.Result.Id;
        }
    }

}
