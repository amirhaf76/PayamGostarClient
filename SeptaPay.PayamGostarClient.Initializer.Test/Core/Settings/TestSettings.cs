using Microsoft.Extensions.Configuration;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Test.Core.Settings
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