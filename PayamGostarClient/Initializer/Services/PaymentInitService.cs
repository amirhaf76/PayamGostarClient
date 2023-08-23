using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class PaymentInitService : BaseInitService<CrmPaymentModel>
    {
        internal PaymentInitService(CrmPaymentModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient, IInitServiceAbstractFactory factory) : base(intendedCrmObject, payamGostarApiClient, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.PaymentApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }
    }

}
