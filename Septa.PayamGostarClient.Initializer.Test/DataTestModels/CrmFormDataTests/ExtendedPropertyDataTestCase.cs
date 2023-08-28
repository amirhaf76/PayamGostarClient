using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Test.DataTestModels.CrmFormDataTests
{
    internal class ExtendedPropertyDataTestCase
    {
        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndTextExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleNumberExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultNumberExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleCheckboxExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultCheckBoxExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleAppointmentExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultAppointmentExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleCrmFormMultiValueExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateCrmFormMultiValueExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleCurrencyExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultCurrencyExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleDropDownListExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultDropDownListExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleFormExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultFormExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleFileExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultFileExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleUserExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultUserExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleDepartmentExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultDepartmentExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimplePositionExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultPositionExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimplePersianDateExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultPersianDateExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleTimeExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultTimeExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleLabelExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultLabelExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> ASimpleCrmFormWithGroupAndASimpleSecurityItemExtendedProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var extendedProperty = DataTest.CreateDefaultSecurityItemExtendedPropertyModel(model.PropertyGroups[0]);

            model.Properties.Add(extendedProperty);

            return new[]
            {
                new object[] { model },
            };
        }

    }
}
