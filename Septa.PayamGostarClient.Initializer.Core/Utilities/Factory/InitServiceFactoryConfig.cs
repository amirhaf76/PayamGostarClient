using Septa.PayamGostarClient.Initializer.Core.APIs;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Factory
{
    public class InitServiceFactoryConfig
    {
        public PayamGostarApiClientConfig ClientService { get; set; }

        public string LanguageCulture { get; set; }
    }


}
