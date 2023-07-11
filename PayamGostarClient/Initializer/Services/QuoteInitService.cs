using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class QuoteInitService : BaseInitService<CrmQuoteModel>
    {
        public QuoteInitService(CrmQuoteModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.QuoteApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }
    }

}
