using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClientTest.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClientTest
{
    public class Samples
    {
        public async Task InitAsync_FormModel_SimpleFormWithGroupAndTextProperty()
        {
            // Set up config.
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = "<Url>",
                    LanguageCulture = "<LanguageCulture>",
                    JwToken = "JWT",
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            // Define a model.
            var model = new CrmFormModel
            {
                Code = "<code>",
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "<CrmName>" }
                },
                PropertyGroups = new List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[]
                        {
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "<CrmGroup>" }
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                }
            };

            model.Properties = new List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "<CrmExtendedPropertyName>" }
                    },
                    UserKey = "<ExtendedPropertyUserKey>",
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };

            // Calling init and passing models.
            await crmModelService.InitAsync(model);
        }

    }
}
