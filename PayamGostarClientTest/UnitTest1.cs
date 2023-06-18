using PayamGostarClient.ApiProvider;
using PayamGostarClient.CrmObjectModelInitServiceModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels;
using PayamGostarClient.Helper.Net;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class UnitTest1
    {
        private const string URL = "http://pgonline-dev.com";
        //private const string URL = "https://webhook.site/eba279bf-0642-4288-9a82-b4e8d15fd276";
        private const string FA_LANGUAGE_CULTURE = "fa-IR";
        private const string EN_LANGUAGE_CULTURE = "en_US";

        private readonly ITestOutputHelper _testOutput;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task Test_Search()
        {

            var clientFactory = new PayamGostarClientFactory(new PayamGostarClientConfig
            {
                LanguageCulture = FA_LANGUAGE_CULTURE,
                ClientApiIntraction = new ClientApiIntraction
                {
                    DomainUrl = URL,
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
        public async Task InitAsync_EmptyModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync();
        }

        [Fact]
        public async Task InitAsync_FormModel_DoNothing()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync(new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "فرم تست ۱", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                Code = "Form_test_20230613"
            });
        }
        [Fact]
        public async Task InitAsync_FormModel_DropDown()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new DropDownListExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Values = new []
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
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });
            model.Properties.Add(new CrmObjectMultiValueExtendedPropertyModel()
            {
                Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                PropertyGroup = groupA,
                UserKey = "EmploymentRequestAds",
                IsRequired = false,
                DefaultValue = string.Empty,
                CrmObjectTypeIndex = PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.Gp_CrmObjectType.Form,
            });

            model.Stages = new System.Collections.Generic.List<Stage>
            {
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 1
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 2
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 3
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 4
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 5
                }
            };
      

            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_5()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "end", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "Start", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var name = $"AutogenFormTest_{Guid.NewGuid()}";

            var textPropertyUserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 1
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 2
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 3
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 4
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 5
                }
            };


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = textPropertyUserKey,
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "number", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تایید شده"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 1
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 2
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 3
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                    },
                    IsDoneStage = false,
                    Enabled = true,
                    Index = 4
                },
                new Stage()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "رد شده"},
                    },
                    IsDoneStage = true,
                    Enabled = true,
                    Index = 5
                }
            };

            await crmModelService.InitAsync(model, model2);
        }

        [Fact]
        public async Task InitAsync_FormModel_3()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);
            var code = $"Auto_gen_Form_test_{Guid.NewGuid()}";
            var name = $"AutogenFormTest_{Guid.NewGuid()}";
            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA
            });


            var model2 = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = name, LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model2.PropertyGroups.Add(groupA2);

            model2.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA2
            });

            model2.Properties.Add(new NumberExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);




            await crmModelService.InitAsync();
        }

        [Fact]
        public void Test1()
        {
            var name1 = new ResourceValue[]
            {
                new ResourceValue { Value = "name1", LanguageCulture = "fa"}
            };

            var name2 = new ResourceValue[]
            {
                new ResourceValue { Value = "name1", LanguageCulture = "en"}
            };


            var res = name1
                .Join(
                    name2,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .All(join => join.Item1 == join.Item2);

            Assert.True(res);
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
        public async Task InitAsync_EmploymentRequestCrmFormModel()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestModel.Create());
        }
        [Fact]
        public async Task InitAsync_EmploymentRequestCrmFormModel_2()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "1stco- آگهی مرتبط با درخواست جذب نیرو"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = "EmploymentRequestAd",
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "اطلاعات محل انتشار"},
                        },
                        CountOfColumns = 1,
                        Expanded = false,
                    }
                },
            };

            var groupA = new PropertyGroup()
            {
                Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مرتبط با فرآیند"},
                        },
                CountOfColumns = 2,
                Expanded = false,
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty2", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_46545646",
                PropertyGroup = groupA
            });
            model.Properties.Add(new CrmObjectMultiValueExtendedPropertyModel()
            {
                Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                PropertyGroup = groupA,
                UserKey = "EmploymentRequestAds",
                IsRequired = false,
                DefaultValue = string.Empty,
                CrmObjectTypeIndex = PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.Gp_CrmObjectType.Form,
            });

        


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_EmploymentRequestAdModel()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);

            await crmModelService.InitAsync(EmploymentRequestAdModel.Create());
        }

        [Fact]
        public async Task InitAsync_FormModel_FixingIsRequired()
        {
            var initServiceConfig = new CrmObjectModelInitServiceConfig
            {
                ClientService = new PayamGostarClient.ApiServices.PayamGostarClientServiceConfig
                {
                    Url = URL,
                    LanguageCulture = FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitService(initServiceConfig);


            var model = new CrmFormModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_{Guid.NewGuid()}", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                    new ResourceValue { Value = "GroupA", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                }
            };

            model.PropertyGroups.Add(groupA);

            model.Properties.Add(new TextExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenTextProperty", LanguageCulture = FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = FA_LANGUAGE_CULTURE },
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
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
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
}