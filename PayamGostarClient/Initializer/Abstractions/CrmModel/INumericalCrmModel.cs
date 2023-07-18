using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;

namespace PayamGostarClient.Initializer.Abstractions.CrmModel
{
    public interface INumericalCrmModel
    {
        NumberingTemplateModel NumberingTemplate { get; set; }
    }
}
