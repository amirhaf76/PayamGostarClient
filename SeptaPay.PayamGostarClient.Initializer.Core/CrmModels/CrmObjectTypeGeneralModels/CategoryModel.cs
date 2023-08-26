using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels
{
    public class CategoryModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.Category;
    }




}
