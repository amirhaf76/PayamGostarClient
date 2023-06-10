using PayamGostarClient.Models;
using System.Threading.Tasks;

namespace PayamGostarClient
{
    public interface IInitService
    {
        Task InitAsync<T>() where T : BaseCRMModel;
    }


    /*
      public class CrmObjectModelInitService : ICrmObjectModelInitService, ITransient
    {
        public void Init(params BaseCRMModel[] crmModels)
        {
            throw new NotImplementedException();
        }

        public async Task InitAsync(params BaseCRMModel[] crmModels)
        {
            var initServiceFactory = new InitServiceFactory();

            foreach (var crmModel in crmModels)
            {
                var initService = initServiceFactory.Create(crmModel);

                await initService.InitAsync<BaseCRMModel>();
            }
        }
    }

    public interface ICrmObjectModelInitService
    {
        void Init(params BaseCRMModel[] crmModels);

        Task InitAsync(params BaseCRMModel[] crmModels);
    }

    public class InitServiceFactory
    {
        public IInitService Create<T>(T model) where T : BaseCRMModel
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService(model);
                default:
                    throw new InvalidGpCrmObjectTypeException();
            }
        }
    }

    public interface IInitService
    {
        Task InitAsync<T>() where T : BaseCRMModel;
    }

    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected BaseCRMModel BaseCrmModel { get; }

        protected BaseInitService(BaseCRMModel baseCrmModel)
        {
            BaseCrmModel = baseCrmModel;
        }

        public Task InitAsync<T1>() where T1 : BaseCRMModel
        {
            throw new NotImplementedException();
        }

        protected abstract T CreateType();
    }


    public class FormInitService : BaseInitService<FormModel>
    {
        public FormInitService(BaseCRMModel baseCrmModel) : base(baseCrmModel)
        {
        }

        protected override FormModel CreateType()
        {
            throw new NotImplementedException();
        }
    }
     */

}
