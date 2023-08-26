using SeptaPay.PayamGostarClient.Initializer.Core;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs;

namespace SeptaPay.PayamGostarClient.Initializer
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
