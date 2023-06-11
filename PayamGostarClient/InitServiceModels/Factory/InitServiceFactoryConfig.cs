using PayamGostarClient.ApiServices;
using System;

namespace PayamGostarClient.InitServiceModels.Factory
{
    public class InitServiceFactoryConfig
    {
        public static InitServiceFactoryConfig Default => throw new NotImplementedException();

        public PayamGostarClientServiceConfig ClientService { get; set; }
    }


}
