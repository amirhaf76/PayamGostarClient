using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System;

namespace PayamGostarClient.InitServiceModels.Models
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(BaseCRMModel baseCrmModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(baseCrmModel, crmObjectTypeApiService)
        {
        }

        protected override CrmFormModel CreateType()
        {
            throw new NotImplementedException();
        }
    }

}
