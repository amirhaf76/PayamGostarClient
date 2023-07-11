using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class TicketInitService : BaseInitService<CrmTicketModel>
    {
        public TicketInitService(CrmTicketModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.TicketApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }

    }
}
