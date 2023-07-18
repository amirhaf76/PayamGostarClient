using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class CategoryModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.Category;
    }




}
