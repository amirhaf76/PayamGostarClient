using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels
{
    public class ProductGroupModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.ProductGroup;
    }
}
