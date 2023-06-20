using FluentAssertions;
using PayamGostarClient.CrmObjectModelInitServiceModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels;
using PayamGostarClient.InitServiceModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class UnitTest3
    {

        private ITestOutputHelper _testOutput;

        public UnitTest3(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_FormModel_SimpleForm()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
            };


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithoutName_ThrowException()
        {
            // Arrangement.
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
            };

            var initAction = new Func<Task>( async() =>
            {
                // Action.
                await crmModelService.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullNameException>();
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithoutCode_ThrowException()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";

            var model = new CrmFormModel
            {
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
            };

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelService.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<NullCrmCodeException>();
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithUnbindedPropertyToGroup_ThrowException()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
                PropertyGroups = new List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[]
                        {
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "GroupA" }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "TextPropertyA" }
                    },
                    UserKey = "UserKeyA",
                    IsRequired = false,
                }
            };

            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value ?? "<null>");
            _testOutput.WriteLine(model.Code ?? "<null>");

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithPropertyThatThereIsNotAnyGroup_ThrowException()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
            };

            model.Properties = new List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "TextPropertyA" }
                    },
                    UserKey = "UserKeyA",
                    IsRequired = false,
                }
            };

            var initAction = new Func<Task>(async () =>
            {
                // Action.
                await crmModelService.InitAsync(model);
            });

            // Assertion.
            await initAction.Should().ThrowExactlyAsync<InvalidGroupCountException>();
        }

        [Fact]
        public async Task InitAsync_FormModel_SimpleFormWithGroup()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
                PropertyGroups = new List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[]
                        {
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "GroupA" }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "TextPropertyA" }
                    },
                    UserKey = "UserKeyA",
                    IsRequired = false,
                }
            };


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_SimpleFormWithGroupAndTextProperty()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
                Name = new[]
                {
                    new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = name }
                },
                PropertyGroups = new List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[]
                        {
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "GroupA" }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "TextPropertyA" }
                    },
                    UserKey = "UserKeyA",
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }
    }
}
