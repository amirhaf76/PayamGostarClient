using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Test
{
    public class Samples
    {
        public async Task InitAsync_FormModel_SimpleFormWithGroupAndTextProperty()
        {
            // Set up config.
            var initServiceConfig = new PayamGostarApiClientConfig
            {
                Url = "<Url>",
                LanguageCulture = "<LanguageCulture>",
                JwToken = "JWT",
            };

            var crmModelService = new CrmObjectModelInitializerRestApi(initServiceConfig);

            // Define a model.
            var model = new CrmFormModel
            {
                Code = "<code>",
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = "fa-IR", Value = "<CrmName>" }
                },
                PropertyGroups = new List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[]
                        {
                            new ResourceValue { LanguageCulture = "fa-IR", Value = "<CrmGroup>" }
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
                        new ResourceValue { LanguageCulture = "fa-IR", Value = "<CrmExtendedPropertyName>" }
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
