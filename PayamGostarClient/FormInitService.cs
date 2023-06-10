using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.Models;
using System;

namespace PayamGostarClient
{
    public class FormInitService : BaseInitService<FormModel>
    {
        public FormInitService(BaseCRMModel baseCrmModel, ICrmObjectTypeApiService crmObjectTypeApiService) : base(baseCrmModel, crmObjectTypeApiService)
        {
        }

        protected override FormModel CreateType()
        {
            throw new NotImplementedException();
        }
    }

}
