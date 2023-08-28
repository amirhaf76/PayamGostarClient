using Septa.PayamGostarClient.RestApi.ClientInteractions;

namespace Septa.PayamGostarClient.RestApi
{
    public class PayamGostarRestApiConfig
    {
        public string LanguageCulture { get; set; }

        public IClientInteraction ClientApiIntraction { get; set; }
    }
}
