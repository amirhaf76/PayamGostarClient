using PayamGostarClient.CrmObjectModelInitServiceModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
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
    public class UnitTest3
    {
        
        private ITestOutputHelper _testOutput;

        public UnitTest3(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public async Task InitAsync_FormModel_AddingProperty()
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
                Code = "Auto_gen_Form_test_be979f09-d615-4337-881c-14456aeb2a8c",
              
            };


            _testOutput.WriteLine(model.Name.FirstOrDefault()?.Value);
            _testOutput.WriteLine(model.Code);

            await crmModelService.InitAsync(model);
        }
    }
}
