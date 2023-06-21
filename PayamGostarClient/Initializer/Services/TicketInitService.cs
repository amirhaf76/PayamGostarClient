using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class TicketInitService : BaseInitService<CrmTicketModel>
    {
        public TicketInitService(CrmTicketModel intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory) : base(intendedCrmObject, serviceFactory)
        {
        }



        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeTicketService();

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }

    }
}
