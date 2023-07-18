using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class ProductGroupModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.ProductGroup;
    }
}
