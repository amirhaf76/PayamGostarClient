using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
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
using Xunit.Abstractions;

namespace PayamGostarClientTest
{
    public class UnitTest2
    {


        private readonly ITestOutputHelper _testOutput;

        public UnitTest2(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }


        [Fact]
        public async Task InitAsync_FormModel_SimpleTicket()
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
                    Details = new []
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
                Extensions = new []
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
        public async Task InitAsync_FormModel_Appointment()
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
                

            });


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }

        [Fact]
        public async Task InitAsync_FormModel_UserAndGroup()
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

        [Fact]
        public async Task InitAsync_TicketmModel_InterviewTicket()
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


            await crmModelService.InitAsync(InterviewTicketModel.Create());
        }
    }
}
