using PayamGostarClient.Helper.Net;

namespace PayamGostarClient.ApiClient.ApiProvider
{
    public class PayamGostarApiProviderConfig
    {
        public string LanguageCulture { get; set; }

        public IClientApiIntraction ClientApiIntraction { get; set; }
    }
}
