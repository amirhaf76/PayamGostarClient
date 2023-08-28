using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels
{
    public class CategoryModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.Category;
    }




}
