using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Septa.PayamGostarClient.Initializer.Test.DataTestModels.CrmFormDataTests
{
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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(firstGroup));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(firstGroup);

            existedModel.Properties.Add(
                DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(dto =>
                {
                    dto.Group = firstGroup;
                    dto.UserKeyFormat = "textPropertyUserKey_{0:N}";
                }));

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(firstGroup));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(secondGroup);

            existedModel.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(secondGroup));


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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> TwoSimpleFormsWithEquivalentStages()
        {
            const int STAGE_NUMBER = 3;

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_test_name_{guid:N}";
            var code = $"Auto_gen_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            for (int i = 0; i < STAGE_NUMBER - 1; i++)
            {
                var stageName = $"Stage_{i}";
                var stageKey = $"StageKey_{i}";

                model.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
                existedModel.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
            }

            model.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));
            existedModel.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoSimpleFormsWhichTheSecondOneHasOneMoreUnDoneStage()
        {
            const int STAGE_NUMBER = 3;

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_test_name_{guid:N}";
            var code = $"Auto_gen_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            for (int i = 0; i < STAGE_NUMBER - 1; i++)
            {
                var stageName = $"Stage_{i}";
                var stageKey = $"StageKey_{i}";

                model.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
                existedModel.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
            }

            model.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));
            existedModel.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));

            existedModel.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER}", $"stageKey_{STAGE_NUMBER}", enable: true, isDoneStage: false));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> TwoSimpleFormsWhichTheSecondOneHasOneMoreDoneStage()
        {
            const int STAGE_NUMBER = 3;

            var guid = Guid.NewGuid();
            var name = $"Auto_gen_test_name_{guid:N}";
            var code = $"Auto_gen_test_code_{guid:N}";

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            for (int i = 0; i < STAGE_NUMBER - 1; i++)
            {
                var stageName = $"Stage_{i}";
                var stageKey = $"StageKey_{i}";

                model.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
                existedModel.Stages.Add(DataTest.CreateStage(stageName, stageKey, enable: true));
            }

            model.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));
            existedModel.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER - 1}", $"stageKey_{STAGE_NUMBER - 1}", enable: true, isDoneStage: true));

            existedModel.Stages.Add(DataTest.CreateStage($"stage_{STAGE_NUMBER}", $"stageKey_{STAGE_NUMBER}", enable: true, isDoneStage: true));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }
    }
}
