using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models.Services
{
    public class TicketInitService : BaseInitService<CrmTicketModel>
    {
        public TicketInitService(CrmTicketModel intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory) : base(intendedCrmObject, serviceFactory)
        {
        }

        protected override CrmTicketModel CheckCrmObjectMatching(CrmTicketModel currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.ResponseTemplate, currentCrmObj.ResponseTemplate);
            CheckFieldMatching(IntendedCrmObject.ListenLineId, currentCrmObj.ListenLineId);

            if (currentCrmObj.PriorityMatrix.Details.Count() != 9)
            {
                throw new InvalidPriorityMatrixCount();
            }

            // todo: matrix

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

            var gettingTicketResult = await service.GetWithPriorityMatrixAsync(request);

            return gettingTicketResult.Result.ToModel();
        }

    }
}
