using SeptaPay.PayamGostarClient.RestApi.ClientInteractions;

namespace SeptaPay.PayamGostarClient.RestApi
{
    public class PayamGostarRestApiConfig
    {
        public string LanguageCulture { get; set; }

        public IClientInteraction ClientApiIntraction { get; set; }
    }
}
