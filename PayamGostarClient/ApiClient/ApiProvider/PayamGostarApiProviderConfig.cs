using PayamGostarClient.Helper.Net;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarApiProviderConfig
    {
        public string LanguageCulture { get; set; }

        public IClientApiIntraction ClientApiIntraction { get; set; }
    }
}
