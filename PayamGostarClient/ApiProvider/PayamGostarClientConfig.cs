using PayamGostarClient.Helper.Net;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarClientConfig
    {
        public string LanguageCulture { get; set; }

        public IClientApiIntraction ClientApiIntraction { get; set; }
    }
}
