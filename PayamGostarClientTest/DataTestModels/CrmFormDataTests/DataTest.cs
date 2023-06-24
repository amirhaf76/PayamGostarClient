using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClientTest.DataTestModels.CrmFormDataTests
{
    internal static class DataTest
    {
        internal static string LANGUAGE_CULTURE { get; set; } = "fa-IR";


        internal static ResourceValue[] CreateResourceValues(params string[] names)
        {
            var resourceValues = new List<ResourceValue>();

            foreach (var name in names)
            {
                resourceValues.Add(new ResourceValue { LanguageCulture = LANGUAGE_CULTURE, Value = name });
            }

            return resourceValues.ToArray();
        }


        internal static CrmFormModel CreateAnCrmFormWithNewGeneratedCodeAndName(string nameFromat = "Auto_gen_crm_test_name_{0:N}", string codeFromat = "Auto_gen_crm_test_name_{0:N}")
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);
            codeFromat = string.Format(codeFromat, guid);

            return new CrmFormModel
            {
                Code = codeFromat,
                Name = CreateResourceValues(nameFromat),
            };
        }


        internal static PropertyGroup CreateASimplePropertyGroup(string nameFromat = "group", bool expand = false, int countOfColumns = 2)
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);

            return new PropertyGroup
            {
                Name = CreateResourceValues(nameFromat),
                CountOfColumns = countOfColumns,
                Expanded = expand,
            };
        }

        internal static Stage CreateStage(string nameFromat = "stage_{0:N}", string keyFormat = "stageKey_{0:N}", bool enable = false, bool isDoneStage = false, int index = 1)
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);
            keyFormat = string.Format(keyFormat, guid);

            return new Stage
            {
                Name = CreateResourceValues(nameFromat),
                Enabled = enable,
                Index = index,
                IsDoneStage = isDoneStage,
                Key = keyFormat,
            };
        }


        internal static TextExtendedPropertyModel CreateTextExtendedProperty(string nameFromat = "textProperty", string userKeyFromat = "textPropertyUserKey", bool isRequired = false)
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);
            userKeyFromat = string.Format(userKeyFromat, guid);

            return new TextExtendedPropertyModel
            {
                Name = CreateResourceValues(nameFromat),
                UserKey = userKeyFromat,
                IsRequired = isRequired,
            };
        }

        internal static TextExtendedPropertyModel CreateTextExtendedProperty(PropertyGroup group, string nameFromat = "textProperty", string userKeyFromat = "textPropertyUserKey", bool isRequired = false)
        {
            var property = CreateTextExtendedProperty(nameFromat, userKeyFromat, isRequired);

            property.PropertyGroup = group;

            return property;
        }

    }

    internal class CheckExistenceSchemaDataTestCase
    {
        
        public static IEnumerable<object[]> AnUnexistedSimpleFormModelWithoutGroupAndProperties()
        {
            return new[]
            {
                new object[] { DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName() },
            };
        }

        public static IEnumerable<object[]> TwoUnexistedSimpleFormModelWithoutGroupAndProperties()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoUnexistedSimpleFormModelWithJustGroup()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoUnexistedSimpleFormModelWithADifferentGroup()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup(nameFromat: "group_{0:N}"));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoUnexistedSimpleFormModelWithSameGroupAndDifferentTextProperty()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var firstGroup = DataTest.CreateASimplePropertyGroup();


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(firstGroup);

            model.Properties.Add(DataTest.CreateTextExtendedProperty(firstGroup));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(firstGroup);

            existedModel.Properties.Add(DataTest.CreateTextExtendedProperty(firstGroup, userKeyFromat: "textPropertyUserKey_{0:N}"));


            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoUnexistedSimpleFormModelWithDifferentGroupAndSameTextProperty()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var firstGroup = DataTest.CreateASimplePropertyGroup();
            var secondGroup = DataTest.CreateASimplePropertyGroup("group_{0:N}");


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(firstGroup);

            model.Properties.Add(DataTest.CreateTextExtendedProperty(firstGroup));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(secondGroup);

            existedModel.Properties.Add(DataTest.CreateTextExtendedProperty(secondGroup));


            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> AnUnexistedSimpleFormModelWithJustAGroup()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> AnUnexistedSimpleFormModelWithAGroupAndATextProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));

            return new[]
            {
                new object[] { model },
            };
        }


    }

    internal class InitDataTestCase
    {
        public static IEnumerable<object[]> SimpleFormModelWithoutGroupAndProperties()
        {
            return new[]
            {
                new object[] { DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName() },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithoutGroupAndPropertiesAndCode()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.Code = string.Empty;

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithoutGroupAndPropertiesAndName()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.Name = Array.Empty<ResourceValue>();

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithJustAGroup()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithAGroupAndATextProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithAGroupAndAProperty()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(DataTest.CreateTextExtendedProperty(existedModel.PropertyGroups[0]));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithEmptyExtendedUserKey()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var property = DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]);

            property.UserKey = string.Empty;

            model.Properties.Add(property);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithPropertyThatThereIsNotAnyGroup()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            var group = DataTest.CreateASimplePropertyGroup();

            model.Properties.Add(DataTest.CreateTextExtendedProperty(group));

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithAGroupAndAnExtraProperty()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(DataTest.CreateTextExtendedProperty(existedModel.PropertyGroups[0]));

            existedModel.Properties.Add(
                DataTest.CreateTextExtendedProperty(
                    group: existedModel.PropertyGroups[0],
                    nameFromat: "secondTextProperty",
                    userKeyFromat: "secondTextProperty"));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithAGroupAndJustAnExtraProperty()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(
                DataTest.CreateTextExtendedProperty(
                    group: existedModel.PropertyGroups[0],
                    nameFromat: "secondTextProperty",
                    userKeyFromat: "secondTextProperty"));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithSameUserKeys()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0]));

            model.Properties.Add(DataTest.CreateTextExtendedProperty(model.PropertyGroups[0], nameFromat: "SecondTextProperty"));

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithUnbindedPropertyToGroup()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            model.Properties.Add(DataTest.CreateTextExtendedProperty());

            return new[]
            {
                new object[] { model },
            };
        }
    }
}
