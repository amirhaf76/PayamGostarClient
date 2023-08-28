using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel
{
    public interface INumericalCrmModel
    {
        NumberingTemplateModel NumberingTemplate { get; set; }
    }
}
