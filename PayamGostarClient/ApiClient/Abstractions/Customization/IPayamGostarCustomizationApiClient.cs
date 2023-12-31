﻿using PayamGostarClient.ApiClient.Abstractions.Customization.Category;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.Abstractions.Customization.Product;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;

namespace PayamGostarClient.ApiClient.Abstractions.Customization
{
    public interface IPayamGostarCustomizationApiClient
    {

        IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi { get; }

        IPayamGostarPropertyGroupApiClient PropertyGroupApi { get; }

        IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi { get; }

        IPayamGostarNumberingTemplateApiClient NumberingTemplateApi { get; }

        IPayamGostarCategoryApiClient CategoryApi { get; }

        IPayamGostarProductGroupApiClient ProductGroupApi { get; }
    }


}