using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels
{
    public class ProductGroupModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.ProductGroup;
    }
}
