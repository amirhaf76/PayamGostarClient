using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel
{
    public interface INumericalCrmModel
    {
        NumberingTemplateModel NumberingTemplate { get; set; }
    }
}
