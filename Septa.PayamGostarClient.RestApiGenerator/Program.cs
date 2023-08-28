using PayamGosterApiGenerator.Core;
using Septa.PayamGostarClient.RestApi;

var paths = new List<string>();


paths.Add(await CreateSampleSwaggerClientAsync());

paths.ForEach(e => Console.WriteLine(e));


static async Task<string> CreateSampleSwaggerClientAsync()
{
    var baseType = typeof(PayamGostarBaseClient);
    var configType = typeof(PayamGostarRestApiConfig);

    var nameSpace = baseType.Namespace ?? "GeneratedRestApi";
    var fileName = baseType.Name.Replace("Base", null);

    var swaggerJsonUrl = "http://pgonline-dev.com/swagger/v2/swagger.json";

    return await ApiClientGeneratorConfig
        .CreateDefaultApiClientGeneratorConfigWithDefaultGeneratorSetting(nameSpace, fileName)
        .ConfigGeneratorSettings(setting =>
        {
            // add your configuration.
            setting.ClientBaseClass = baseType.Name;

            // An interface is used here for dependency injection.
            setting.ConfigurationClass = configType.Name;
            setting.UseHttpClientCreationMethod = true;

            setting.CSharpGeneratorSettings.ArrayType = "IEnumerable";
            setting.CSharpGeneratorSettings.JsonLibrary = NJsonSchema.CodeGeneration.CSharp.CSharpJsonLibrary.NewtonsoftJson;

        })
        .SetAddressUrl(swaggerJsonUrl)
        .GenerateClientFileAndSaveAsync();
}

