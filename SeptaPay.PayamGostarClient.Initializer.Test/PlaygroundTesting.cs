using PayamGostarClientTest.Constants;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Exceptions;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Helper;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.ClientInteractions;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class PlaygroundTesting
    {
        private readonly ITestOutputHelper _testOutput;

        public PlaygroundTesting(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task Test_Search()
        {

            var clientFactory = new PayamGostarRestApiClientFactory(new PayamGostarRestApiConfig
            {
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                ClientApiIntraction = new ClientInteraction
                {
                    DomainUrl = MarkedUrl.URL,
                    JwtToken = JwTokenRepository.JWTOKEN,
                    // DeviceId
                    // ClientId
                },
            });

            var client = clientFactory.CreateCrmObjectTypeApiClient();

            var result = await client.PostApiV2CrmobjecttypeSearchAsync(new CrmObjectTypeSearchRequestVM
            {
                Code = "NJsonSchemaTest_Form"
            });

            var t = result.Result.Items.FirstOrDefault()?.Properties?.FirstOrDefault()?.ExtraConfiguration as ImageFilePropertyDefinitionExtraConfigs;

        }

        [Fact]
        public void Test()
        {
            var b = new B
            {
                Name = "name1",
                Id = 1,
                A = new A
                {
                    Id = 2,
                    Name = "name2"
                },
                SubB = new B
                {
                    Name = "name1",
                    Id = 1,
                    A = new A { Id = 2, Name = "name2" },
                    SubB = null
                },
                Objects = new[]{
                    new A
                    {
                        Id = 2,
                        Name = "name2"
                    },
                        new A
                    {
                        Id = 2,
                        Name = "name2"
                    },
                }
            };

            _testOutput.WriteLine(Help.GetStringsFromProperties(b.GetType(), b, 3));
        }

        [Fact]
        public void Test231()
        {
            try
            {
                throw ApiServiceException.Create("Hello");

            }
            catch (Exception e)
            {
                _testOutput.WriteLine(e.Message);
            }
        }

        [Fact]
        public async Task Test232()
        {
            var config = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
            {
                Url = "https://webhook.site/f7beebfa-b533-40cc-a39e-c90790b57a63",
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                BasicParam = "YWRtaW46YWRtaW4="
            };

            var client = new PayamGostarApiClient(config);

            var request = new FormExtendedPropertyCreationDto
            {
                PreventSettingContainerCrmobjectAsParent = false,
                ReferencedItemCrmObjectTypeId = Guid.NewGuid(),
            };

            var res = await client.CustomizationApi.ExtendedPropertyApi.CreateAsync(request);
        }

        [Fact]
        public async Task InitAsync_EmptyModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            await crmModelService.InitAsync();
        }

        [Fact]
        public async Task InitAsync_FormModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            await crmModelService.InitAsync(new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "فرم تست ۱", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = "Form_test_20230613"
            });
        }
        [Fact]
        public async Task InitAsync_FormModel_DropDown()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = $"Auto_gen_Form_test_{Guid.NewGuid()}",
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new DropDownListExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Values = new[]
                {
                    new DropDownListExtendedPropertyValueModel
                    {
                        Value = "Item1"
                    },
                    new DropDownListExtendedPropertyValueModel
                    {
                        Value = "Item2"
                    },
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,

            });





            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = $"Auto_gen_Form_test_{Guid.NewGuid()}",
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });
            model.Properties.Add(new CrmObjectMultiValueExtendedPropertyModel()
            {
                Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                PropertyGroup = groupA,
                UserKey = "EmploymentRequestAds",
                DefaultValue = string.Empty,
                CrmObjectTypeIndex = PayamGostarClient.Initializer.Service.Enums.Gp_CrmObjectType.Form,
            });

            model.Stages = new System.Collections.Generic.List<Stage>
            {
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                }
            };


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_5()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = $"Auto_gen_Form_test_{Guid.NewGuid()}",
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            var finalStage = new Stage
            {
                Enabled = true,
                IsDoneStage = true,
                Key = "myKey",
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "end", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            var startStage = new Stage
            {
                Enabled = true,
                IsDoneStage = true,
                Key = "myKey",
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "Start", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.Stages.Add(finalStage);
            model.Stages.Add(startStage);

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });



            //var newModel = new CrmFormModel
            //{
            //    PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
            //    {
            //        new PropertyGroup()
            //        {
            //            Name = new[]
            //            {
            //                new ResourceValue(){ Value = "", LanguageCulture = ""}, 
            //                new ResourceValue() { Value = "ds", } 
            //            },
            //            CountOfColumns = 1,
            //            Expanded = true,
            //        }
            //    }

            //};

            //newModel.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            //    {
            //        new NumberExtendedPropertyModel()
            //        {
            //            Name = new[]
            //            {
            //                new ResourceValue(){ Value = "", LanguageCulture = ""},
            //                new ResourceValue() { Value = "ds", }
            //            },
            //            PropertyGroup =newModel.PropertyGroups[0],
            //        }
            //    };

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_2()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var name = $"AutogenFormTest_{Guid.NewGuid()}";

            var textPropertyUserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = textPropertyUserKey,
                PropertyGroup = groupA
            });

            model.Stages = new System.Collections.Generic.List<Stage>
            {
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true
                }
            };


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA2 = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = textPropertyUserKey,
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "number", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2,
                MinDigits = 1,
                MaxDigits = 10,
                MaxValue = 10000,
                MinValue = -1,
                DecimalDigits = 1,
            });

            model2.Stages = new System.Collections.Generic.List<Stage>
            {
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true
                }
            };

            await crmModelService.InitAsync(model, model2);
        }

        [Fact]
        public async Task InitAsync_FormModel_3()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA2 = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2,
                MinDigits = 1,
                MaxDigits = 10,
                MaxValue = 10000,
                MinValue = -1,
                DecimalDigits = 1,
            });

            await crmModelService.InitAsync(model, model2);
        }

        [Fact]
        public async Task InitAsync_FormModel_4()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var name = $"AutogenFormTest_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = code,
            };

            var groupA2 = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2,
                MinDigits = 1,
                MaxDigits = 10,
                MaxValue = 10000,
                MinValue = -1,
                DecimalDigits = 1,
            });

            await crmModelService.InitAsync(model, model2);
        }

        [Fact]
        public async Task InitAsync_EmploymentRequest_()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);




            await crmModelService.InitAsync();
        }

        [Fact]
        public void Test1()
        {
            throw ApiServiceException.Create("fmmmmmmmm");
        }

        [Fact]
        public void Test2()
        {
            var name1 = new ResourceValue[]
            {
                new ResourceValue { Value = "name1", LanguageCulture = "fa"}
            };

            var name2 = new ResourceValue[]
            {
                new ResourceValue { Value = "name1", LanguageCulture = "fa"}
            };

            var joinedName = name1
                .Join(
                    name2,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .ToList();

            var res = joinedName
                .All(join => join.Item1 == join.Item2);

            Assert.True(res);
        }

        [Fact]
        public void Test3()
        {
            var name1 = new ResourceValue[]
            {
                new ResourceValue { Value = "name1", LanguageCulture = "fa"}
            };

            var name2 = new ResourceValue[]
            {
                new ResourceValue { Value = "name2", LanguageCulture = "fa"}
            };

            var joinedName = name1
                .Join(
                    name2,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .ToList();

            var res = joinedName
                .All(join => join.Item1 == join.Item2);

            Assert.False(res);

        }





        [Fact]
        public async Task InitAsync_FormModel_FixingIsRequired()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = $"Auto_gen_Form_test_{Guid.NewGuid()}",
            };

            var groupA = new PropertyGroup
            {
                CountOfColumns = 1,
                Expanded = true,
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "GroupA", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,
                IsRequired = true,
            });
            model.Properties.Add(new UserExtendedPropertyModel()
            {
                Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                PropertyGroup = groupA,
                UserKey = "Auto_gen_text_property_test_{Guid.NewGuid()}",
                IsRequired = true,
                DefaultValue = string.Empty,
            });




            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

    }

    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public A A { get; set; }
        public B SubB { get; set; }

        public IEnumerable<A> Objects { get; set; }


    };


}