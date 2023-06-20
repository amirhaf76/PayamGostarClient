using PayamGostarClient.CrmObjectModelInitServiceModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PayamGostarClientTest
{
    public class Samples
    {
        public async Task InitAsync_FormModel_SimpleFormWithGroupAndTextProperty()
        {
            // Set up config.
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = "<Url>",
                    LanguageCulture = "<LanguageCulture>",
                    JwToken = "JWT",
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

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
