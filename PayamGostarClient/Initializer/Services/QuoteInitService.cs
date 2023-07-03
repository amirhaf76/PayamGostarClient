using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class QuoteInitService : BaseInitService<CrmQuoteModel>
    {
        public QuoteInitService(CrmQuoteModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
            throw new NotImplementedException("QuoteInitService is not Implemented");
        }

        protected override Task<Guid> CreateTypeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
