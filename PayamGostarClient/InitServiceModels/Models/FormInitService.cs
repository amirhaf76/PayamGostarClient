using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System;

namespace PayamGostarClient.InitServiceModels.Models
{
    public class FormInitService : BaseInitService<FormModel>
    {
        public FormInitService(BaseCRMModel baseCrmModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(baseCrmModel, crmObjectTypeApiService)
        {
        }

        protected override FormModel CreateType()
        {
            throw new NotImplementedException();
        }
    }

}
