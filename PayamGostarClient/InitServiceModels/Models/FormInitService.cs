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

            return gettingCrmObjectResult.Result.ToModel();
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var creationResult = await service.CreateAsync(IntendedCrmObject.ToDto());

            return creationResult.Result.Id;
        }
    }

}
