using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models.Services
{
    internal class TicketInitService : BaseInitService<CrmTicketModel>
    {
        public TicketInitService(CrmTicketModel intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory) : base(intendedCrmObject, serviceFactory)
        {
        }

        protected override CrmTicketModel CheckCrmObjectMatching(CrmTicketModel currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.ResponseTemplate, currentCrmObj.ResponseTemplate);

            return currentCrmObj;
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeTicketService();

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }

        protected override async Task<CrmTicketModel> GetCrmObjectTypeAsync(Guid id)
        {
            var service = ServiceFactory.CreateCrmObjectTypeTicketService();

            var request = new CrmObjectTypeGetRequestDto
            {
                Id = id,
            };

            var gettingTicketResult = await service.GetAsync(request);

            return gettingTicketResult.Result.ToModel();
        }

        //        CrmObjectTypeTicketGetResultDto
        //CrmObjectTypeGetRequestDto
        //CrmObjectTypeResultDto
        //CrmObjectTypeTicketCreateRequestDto

    }
}
