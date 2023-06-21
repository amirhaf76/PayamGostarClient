using FluentAssertions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.Initializer;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class InitScenarios
    {
        private ITestOutputHelper _testOutput;

        public InitScenarios(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithoutGroupAndProperties_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

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

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelService.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
            });

        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithGroup_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";
            var groupName = "GroupTest";

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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                }
            };

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelService.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new []
                {
                    new
                    {
                        Name = groupName,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                }
            });
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithGroupWithTextProperty_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";
            var groupName = "GroupTest";
            var textPropertyName = "TestTextProperty";
            var textPropertyNameKey = "TestTextPropertyKey";

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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            // Assertion Before.
            var searchedObjectBefore = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectBefore.Result.Should().HaveCount(0);

            // Action.
            await crmModelService.InitAsync(model);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)model.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = groupName,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = textPropertyName,
                        UserKey = textPropertyNameKey,
                    }
                }
            });
        }

        [Fact]
        public async Task InitAsync_ExistedSimpleFormModel_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";
            var groupName = "GroupTest";
            var textPropertyName = "TestTextProperty";
            var textPropertyNameKey = "TestTextPropertyKey";

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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };

            var existedModel = new CrmFormModel
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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                }
            };

            existedModel.Properties = new List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = existedModel.PropertyGroups[0],
                }
            };

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(model);

            // Action.
            await crmModelService.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)existedModel.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = groupName,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = textPropertyName,
                        UserKey = textPropertyNameKey,
                    }
                }
            });
        }

        [Fact]
        public async Task InitAsync_ExistedSimpleFormModelWithNewTextProperty_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";
            var groupName = "GroupTest";
            var textPropertyName = "TestTextProperty";
            var newTextPropertyName = "NewTestTextProperty";
            var textPropertyNameKey = "TestTextPropertyKey";
            var newTextPropertyNameKey = "NewTestTextPropertyKey";

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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };

            var existedModel = new CrmFormModel
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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                }
            };

            existedModel.Properties = new List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = existedModel.PropertyGroups[0],

                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = newTextPropertyName }
                    },
                    UserKey = newTextPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = existedModel.PropertyGroups[0],
                }
            };

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(model);

            // Action.
            await crmModelService.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)existedModel.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = groupName,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = textPropertyName,
                        UserKey = textPropertyNameKey,
                    },
                    new
                    {
                        Name = newTextPropertyName,
                        UserKey = newTextPropertyNameKey,
                    }
                }
            });
        }

        [Fact]
        public async Task InitAsync_ExistedSimpleFormModelWithJustNewTextProperty_CreateSuccessfuly()
        {
            // Arrangement.
            var payamGostarClientServiceConfig = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
            {
                Url = MarkedUrl.URL,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = payamGostarClientServiceConfig,
            };

            var apiServiceFactory = new PayamGostarClientServiceFactory(payamGostarClientServiceConfig);

            var service = apiServiceFactory.CreateCrmObjectTypeService();

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid}";
            var code = $"Auto_gen_Form_test_code_{guid}";
            var groupName = "GroupTest";
            var textPropertyName = "TestTextProperty";
            var newTextPropertyName = "NewTestTextProperty";
            var textPropertyNameKey = "TestTextPropertyKey";
            var newTextPropertyNameKey = "NewTestTextPropertyKey";

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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
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
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = textPropertyName }
                    },
                    UserKey = textPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = model.PropertyGroups[0],
                }
            };

            var existedModel = new CrmFormModel
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
                            new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = groupName }
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                }
            };

            existedModel.Properties = new List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = newTextPropertyName }
                    },
                    UserKey = newTextPropertyNameKey,
                    IsRequired = false,
                    PropertyGroup = existedModel.PropertyGroups[0],
                }
            };

            _testOutput.WriteLine($"Name: {model.Name.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(model);

            // Action.
            await crmModelService.InitAsync(existedModel);

            // Assertion After.
            var searchedObjectAfter = await service.SearchAsync(new CrmObjectTypeSearchRequestDto { Code = code, CrmOjectTypeIndex = (int)existedModel.Type });

            searchedObjectAfter.Result.Should().HaveCount(1);
            searchedObjectAfter.Result.FirstOrDefault().Id.Should().NotBeEmpty();
            searchedObjectAfter.Result.FirstOrDefault().Should().BeEquivalentTo(new
            {
                Name = name,
                Code = code,
                CrmOjectTypeIndex = (int)model.Type,
                Enabled = true,
                Groups = new[]
                {
                    new
                    {
                        Name = groupName,
                        CountOfColumns = 2,
                        ExpandForView = false,
                    }
                },
                Properties = new[]
                {
                    new
                    {
                        Name = textPropertyName,
                        UserKey = textPropertyNameKey,
                    },
                    new
                    {
                        Name = newTextPropertyName,
                        UserKey = newTextPropertyNameKey,
                    }
                }
            });
        }

        [Fact]
        public async Task InitAsync_SimpleFormModelWithoutName_ThrowException()
        {
            // Arrangement.
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var guid = Guid.NewGuid();
            var code = $"Auto_gen_Form_test_code_{guid}";

            var model = new CrmFormModel
            {
                Code = code,
            };

            var initAction = new Func<Task>(async () =>
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
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

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
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

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
                    PropertyGroup = model.PropertyGroups[0],
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
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

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

    }
}
