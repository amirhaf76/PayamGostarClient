using FluentAssertions;
using PayamGostarClientTest.Constants;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class PlaygroundTesting2
    {
        private readonly ITestOutputHelper _testOutput;

        public PlaygroundTesting2(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_CreateNumberingTemplate()
        {
            var config = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL_PG,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var payamGostarApiClient = new PayamGostarClient.ApiClient.PayamGostarApiClient(config);

            var request = new NumberingTemplateCreationRequestDto
            {
                Name = $"Pattern_{Guid.NewGuid():N}",
                InitialSeed = 10,
                LastNumber = 20,
                Prefix = "Pattern_{____(SHYY)}_{*(AN)}",
                ResetNumberInNewPrefix = true,
            };

            var numberingTemplate = await payamGostarApiClient.CustomizationApi.NumberingTemplateApi.CreateAsync(request);

            numberingTemplate.Result.NumberingTemplateId.Should().NotBe(default);
            numberingTemplate.Result.Should().BeEquivalentTo(new
            {
                request.Name,
                request.Prefix,
                request.ResetNumberInNewPrefix,
                InitialSeed = request.InitialSeed.ToString(),
                LastNumber = request.LastNumber.ToString(),
            });

            _testOutput.WriteLine(request.Name);
            _testOutput.WriteLine(request.Prefix);
        }

        private async Task<NumberingTemplateCreationResultDto> CreateNumberingTemplate()
        {
            var config = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
            {
                Url = MarkedUrl.URL_PG,
                LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                JwToken = JwTokenRepository.JWTOKEN,
            };

            var payamGostarApiClient = new PayamGostarClient.ApiClient.PayamGostarApiClient(config);

            var request = new NumberingTemplateCreationRequestDto
            {
                Name = $"Pattern_{Guid.NewGuid():N}",
                InitialSeed = 0,
                LastNumber = 0,
                Prefix = "Pattern_{*(AN)}",
                ResetNumberInNewPrefix = true,
            };

            return (await payamGostarApiClient.CustomizationApi.NumberingTemplateApi.CreateAsync(request)).Result;
        }

        private CrmBaseInvoiceModel FillBaseInvoiceModelWithTestDataSeryOne(CrmBaseInvoiceModel model)
        {
            var guild = Guid.NewGuid();
            model.Code = $"baseInvoice_key_{guild:N}";

            model.Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = $"invoice_{guild:N}" } };
            model.AssignCustomerNumberOnApprove = true;

            model.EventTypes = new[] { WebhookEventType.Insert };
            model.NeedApproval = true;
            model.NeedNumbering = true;
            model.ChangeToStatePendingOnUpdate = true;

            model.CanChangeTotalDiscount = true;
            model.CanChangeTotalTax = true;
            model.CanChangeTotalToll = true;
            model.DisableDecimalCalculation = false;


            model.CountDecimalDigits = 2;

            model.Tax = 30;
            model.Toll = 10;

            model.AdditionalCosts = new AdditionalCostModel
            {
                AdditionalCostsPlacement = Gp_AdditionalCostsPlacementType.BeforeTax,
                InvoiceAdditionalCost = Gp_InvoiceAdditionalCostType.Percentage,
                AdditionalCostIncludedTax = false,
                AdditionalCostIncludedToll = false,
                AdditionalCostsTitle = "Additional",
                AdditionalCostsAmount = 50.20M,
            };

            return model;
        }

        private CrmBasePaymentModel FillBasePaymentModelWithTestDataSeryOne(CrmBasePaymentModel model)
        {
            var guild = Guid.NewGuid();
            model.Code = $"baseInvoice_key_{guild:N}";

            model.Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = $"invoice_{guild:N}" } };
            model.AssignCustomerNumberOnApprove = true;

            model.EventTypes = new[] { WebhookEventType.Insert };

            model.NeedApproval = true;
            model.NeedNumbering = true;
            model.ChangeToStatePendingOnUpdate = true;

            model.CustomerPaymentType = new[] { Gp_PaymentType.Cash, Gp_PaymentType.Cheque };

            return model;
        }

        [Fact]
        public async Task InitAsync_Invoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmInvoiceModel
            {
                AutoGenerateInventoryTransaction = false,
                AutoTransactionTypeId = null,

                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_ReturnPurchaseInvoic_CrmObjectProperty()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var model = new SuperCrmModel
            {
                Type = Gp_CrmObjectType.ReturnPurchaseInvoice,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup
                    {
                        Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "Group A" } },
                    },
                    new PropertyGroup
                    {
                        Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "Group B" } },
                    }
                }
            };

            model.Properties.AddRange(new BaseExtendedPropertyModel[]
            {
                new TextExtendedPropertyModel
                {
                    Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "Text A" } },
                    UserKey = "userKeyTA",
                    PropertyGroup = model.PropertyGroups[0],
                },
                new UserExtendedPropertyModel
                {
                    Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "User A" } },
                    UserKey = "userKeyUA",
                    PropertyGroup = model.PropertyGroups[0],
                },
                new NumberExtendedPropertyModel
                {
                    Name = new[] { new ResourceValue { LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE, Value = "Number A" } },
                    UserKey = "userKeyNA",
                    PropertyGroup = model.PropertyGroups[1],
                }
            });

            _testOutput.WriteLine($"Type: {model.Type}");


            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_PurchaseInvoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmPurchaseInvoiceModel
            {
                AutoGenerateInventoryTransaction = false,
                AutoTransactionTypeId = null,

                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_ReturnPurchaseInvoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmReturnPurchaseInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_ReturnSaleInvoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmReturnSaleInvoiceModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_QuoteInvoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmQuoteModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_PurchaseQuoteInvoice()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBaseInvoiceModelWithTestDataSeryOne(new CrmPurchaseQuoteModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }


        [Fact]
        public async Task InitAsync_Payment()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBasePaymentModelWithTestDataSeryOne(new CrmPaymentModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }

        [Fact]
        public async Task InitAsync_Receipt()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = MarkedUrl.URL_PG,
                    LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE,
                    JwToken = JwTokenRepository.JWTOKEN,
                }
            };

            var crmModelService = new CrmObjectModelInitializer(initServiceConfig);

            var numberingTemplate = new NumberingTemplateModel
            {
                Name = "my_pattern",
                Prefix = "my_pattern_{*(AN)}",
            };

            var model = FillBasePaymentModelWithTestDataSeryOne(new CrmReceiptModel
            {
                NumberingTemplate = numberingTemplate,
            });

            _testOutput.WriteLine($"Name: {model.Name?.FirstOrDefault()?.Value}");
            _testOutput.WriteLine($"Code: {model.Code}");

            await crmModelService.InitAsync(numberingTemplate, model);
        }




        [Fact]
        public async Task InitAsync_FormModel_SimpleTicket()
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


            var model = new CrmTicketModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = $"AutogenFormTest_", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ResponseTemplate = "",
                Code = $"Auto_gen_Form_test_c66bbcb0-3543-41f3-a3d9-2cad178a824d",
                ListenLineId = Guid.Parse("eb7fbe77-37b2-4ac7-95d4-96f09d5bafbe"),
                PriorityMatrix = new PriorityMatrixModel
                {
                    Details = new[]
                    {
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Low,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.Low,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Low,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },


                    }
                }
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

                UserKey = $"Auto_gen_text_property_test_368cd4b6-b1ba-4981-8375-92305810af1d",
                PropertyGroup = groupA
            });

            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_File()
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

            model.Properties.Add(new FileExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,
                Extensions = new[]
                {
                    "jpg", "png"
                },
                FileSizeTypeIndex = FileSizeType.Megabyte,
                MaxFileSize = 31,

            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_Time()
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

            model.Properties.Add(new TimeExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,


            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_Currency()
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

            model.Properties.Add(new CurrencyExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,


            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_CheckBox()
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

            model.Properties.Add(new CheckboxExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,


            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_Text()
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

                Code = $"Auto_gen_Form_test_{Guid.NewGuid():N}",
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
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid():N}",
                PropertyGroup = groupA,
                IsMultiLine = true

            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_Appointment()
        {
            var initServiceConfig = new CrmObjectModelInitializerConfig
            {
                ClientService = new PayamGostarClient.ApiClient.PayamGostarApiClientConfig
                {
                    Url = "https://webhook.site/f7beebfa-b533-40cc-a39e-c90790b57a63",
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

            model.Properties.Add(new AppointmentExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,
                PreventSettingContainerCrmobjectAsParent = false,
                ReferencedItemCrmObjectTypeId = Guid.NewGuid(),


            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_UserAndGroup()
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

            model.Properties.Add(new SecurityItemExtendedPropertyModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { Value = "AutogenProperty", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "Test form 1", LanguageCulture = EN_LANGUAGE_CULTURE }
                },
                ToolTip = new ResourceValue[]
                {
                    new ResourceValue { Value = "توضیحات فارسی", LanguageCulture = LanguageCulture.FA_LANGUAGE_CULTURE },
                    //new ResourceValue { Value = "English Descrpition", LanguageCulture = EN_LANGUAGE_CULTURE }
                },

                UserKey = $"Auto_gen_text_property_test_{Guid.NewGuid()}",
                PropertyGroup = groupA,


            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

    }
}
