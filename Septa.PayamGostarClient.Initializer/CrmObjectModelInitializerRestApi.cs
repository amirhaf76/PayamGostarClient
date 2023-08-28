using Septa.PayamGostarClient.Initializer.Core;
using Septa.PayamGostarClient.Initializer.Core.APIs;

namespace Septa.PayamGostarClient.Initializer
{
    public class CrmObjectModelInitializerRestApi : CrmObjectModelInitializer
    {
        public CrmObjectModelInitializerRestApi(PayamGostarApiClientConfig config, string languageCulture) : base(new PayamGostarApiClient(config), languageCulture)
        {

        }

        public CrmObjectModelInitializerRestApi(PayamGostarApiClientConfig config) : this(config, "fa-IR")
        {

        }
    }
}
