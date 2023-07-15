using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Enums;
using System;

namespace PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels
{
    public class CategoryModel : ICustomizationCrmModel
    {
        public string Name { get; set; }

        public string UserKey { get; set; }

        public bool AddedByUser { get; set; }

        public Guid? OwnerUserId { get; set; }

        public Guid? ParentId { get; set; }

        public CustomizationCrmType CustomizationCrmType => CustomizationCrmType.Category;
    }




}
