using PayamGosterApiGenerator.Core;

var paths = new List<string>();


paths.Add(await CreateSampleSwaggerClientAsync());

paths.ForEach(e => Console.WriteLine(e));


static async Task<string> CreateSampleSwaggerClientAsync()
{
    const string NAME_SPACE = "PayamGostarClient.ApiProvider";
    const string FILE_NAME = "PayamGostarClient";

    var swaggerJsonUrl = "http://pgonline-dev.com/swagger/v2/swagger.json";

    return await ApiClientGeneratorConfig
        .CreateDefaultApiClientGeneratorConfigWithDefaultGeneratorSetting(NAME_SPACE, FILE_NAME)
        .ConfigGeneratorSettings(setting =>
        {
            // add your configuration.
            setting.ClientBaseClass = "PayamGostarBaseClient";

            // An interface is used here for dependency injection.
            setting.ConfigurationClass = "PayamGostarApiProviderConfig";
            setting.UseHttpClientCreationMethod = true;

            setting.CSharpGeneratorSettings.ArrayType = "IEnumerable";
            setting.CSharpGeneratorSettings.JsonLibrary = NJsonSchema.CodeGeneration.CSharp.CSharpJsonLibrary.NewtonsoftJson;

        })
        .SetAddressUrl(swaggerJsonUrl)
        .GenerateClientFileAndSaveAsync();
}

