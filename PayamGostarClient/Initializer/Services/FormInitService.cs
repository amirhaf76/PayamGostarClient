using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(CrmFormModel crmFormModel, IPayamGostarApiClient payamGostarApiClient) : base(crmFormModel, payamGostarApiClient)
        {
        }

        internal FormInitService(CrmFormModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient, IInitServiceAbstractFactory factory) : base(intendedCrmObject, payamGostarApiClient, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.FormApi;

            var creationResult = await service.CreateAsync(IntendedCrmObject.ToDto());

            return creationResult.Result.Id;
        }


    }

}
