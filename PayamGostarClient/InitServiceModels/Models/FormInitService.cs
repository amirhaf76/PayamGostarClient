using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(CrmFormModel crmFormModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(crmFormModel, crmObjectTypeApiService)
        {
        }


        protected override Task<CrmFormModel> CheckAndModifyCrmPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task<CrmFormModel> CreateTypeAsync()
        {

            throw new NotImplementedException();
        }
    }

}
