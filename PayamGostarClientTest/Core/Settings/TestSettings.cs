using Microsoft.Extensions.Configuration;
using System;

namespace PayamGostarClientTest
{
    public class TestSettings 
    { 
        public TestSettingsDto GetSettings(string name = "testsettings.json")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile(name)
                .Build();

            return config.Get<TestSettingsDto>();
        }
    }

}