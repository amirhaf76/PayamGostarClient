using PayamGostarClient.Initializer.CrmModels;

namespace PayamGostarClientTest.DataTestModels.CrmFormDataTests
{
    internal class BaseExtendedPropertyDataTestDto
    {
        /// <summary>
        /// It can be Added guid in format like: property_{0:N}. The result is 'property_66d904e7e8e943f5974f8e6251e10fe9'.
        /// </summary>
        public string UserKeyFormat { get; set; }

        /// <summary>
        /// It can be Added guid in format like: property_{0:N}. The result is 'property_66d904e7e8e943f5974f8e6251e10fe9'.
        /// </summary>
        public string NameFormat { get; set; }

        /// <summary>
        /// It can be Added guid in format like: property_{0:N}. The result is 'property_66d904e7e8e943f5974f8e6251e10fe9'.
        /// </summary>
        public string ToolTipFormat { get; set; }

        public bool IsRequired { get; set; }

        public string DefaultValue { get; set; }

        public PropertyGroup Group { get; set; }

        public static BaseExtendedPropertyDataTestDto Default => new BaseExtendedPropertyDataTestDto
        {
            IsRequired = false,
            DefaultValue = string.Empty,
            UserKeyFormat = "propertyUserKey",
            NameFormat = "proprtyName",
            ToolTipFormat = "proprtyToolTip",
            Group = null,
        };

    }
}
