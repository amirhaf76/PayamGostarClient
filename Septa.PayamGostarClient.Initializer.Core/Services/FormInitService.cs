using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Services
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        internal FormInitService(CrmFormModel intendedCrmObject, IInitServiceAbstractFactory factory) : base(intendedCrmObject, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.FormApi;

            var creationResult = await service.CreateAsync(IntendedCrmObject.ToDto());

            return creationResult.Id;
        }


    }

}
