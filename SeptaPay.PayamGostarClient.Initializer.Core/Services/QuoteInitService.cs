using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Services
{
    public class QuoteInitService : BaseInitService<CrmQuoteModel>
    {
        internal QuoteInitService(CrmQuoteModel intendedCrmObject, IInitServiceAbstractFactory factory) : base(intendedCrmObject, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.QuoteApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Id;
        }
    }

}
