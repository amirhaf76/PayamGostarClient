using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Test.DataTestModels.CrmFormDataTests
{
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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithAGroupAndATextPropertyAndASuperTextProperty()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup(nameFromat: "group1"));
            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup(nameFromat: "group2"));

            var property = DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]);
            var superModelProperty = DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[1]);

            property.DoesBelongToSuperCrmObjectType = false;
            superModelProperty.DoesBelongToSuperCrmObjectType = true;

            property.UserKey = "userKey1";
            superModelProperty.UserKey = "userKey2";

            model.Properties.Add(property);
            model.Properties.Add(superModelProperty);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithStages()
        {
            const int NORMAL_STAGE_COUNT = 3;

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.Stages.Add(
                DataTest.CreateStage(
                    nameFromat: $"stage_{NORMAL_STAGE_COUNT + 1}",
                    keyFormat: $"stageKey_{NORMAL_STAGE_COUNT + 1}",
                    enable: true,
                    isDoneStage: true));

            model.Stages.Add(
                DataTest.CreateStage(
                    nameFromat: $"stage_{NORMAL_STAGE_COUNT + 2}",
                    keyFormat: $"stageKey_{NORMAL_STAGE_COUNT + 2}",
                    enable: true,
                    isDoneStage: true));

            for (int i = 1; i <= NORMAL_STAGE_COUNT; i++)
            {
                model.Stages.Add(DataTest.CreateStage(nameFromat: $"stage_{i}", keyFormat: $"stageKey_{i}", enable: true, isDoneStage: false));
            }

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithUnDoneStages()
        {
            const int NORMAL_STAGE_COUNT = 1;

            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.Stages.Add(
                DataTest.CreateStage(
                    nameFromat: $"stage_{NORMAL_STAGE_COUNT + 1}",
                    keyFormat: $"stageKey_{NORMAL_STAGE_COUNT + 1}",
                    enable: true,
                    isDoneStage: false));

            model.Stages.Add(
                DataTest.CreateStage(
                    nameFromat: $"stage_{NORMAL_STAGE_COUNT + 2}",
                    keyFormat: $"stageKey_{NORMAL_STAGE_COUNT + 2}",
                    enable: true,
                    isDoneStage: false));

            for (int i = 1; i <= NORMAL_STAGE_COUNT; i++)
            {
                model.Stages.Add(DataTest.CreateStage(nameFromat: $"stage_{i}", keyFormat: $"stageKey_{i}", enable: true, isDoneStage: false));
            }

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithDoneStagesAndWithoutKeyForSomeOfThem()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            var stage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);

            var stage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);

            var stage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);

            stage2.Key = string.Empty;

            model.Stages.Add(stage1);
            model.Stages.Add(stage2);
            model.Stages.Add(stage3);

            return new[]
            {
                new object[] { model },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithStagesThatHaveNonUniqueKey()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            var commonKey = "stageKey_commonKey";

            var stage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: commonKey,
                    enable: true,
                    isDoneStage: false);

            var stage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: commonKey,
                    enable: true,
                    isDoneStage: false);

            var stage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);

            model.Stages.Add(stage1);
            model.Stages.Add(stage2);
            model.Stages.Add(stage3);

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(existedModel.PropertyGroups[0]));

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithThreeExistedStages()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);
            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var stage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);
            var existedStage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);

            var stage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);
            var existedStage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);

            var stage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);
            var existedStage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);

            model.Stages.Add(stage1);
            model.Stages.Add(stage2);
            model.Stages.Add(stage3);

            existedModel.Stages.Add(existedStage1);
            existedModel.Stages.Add(existedStage2);
            existedModel.Stages.Add(existedStage3);

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithThreeExistedStagesAndNewUnDoneStage()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);
            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var stage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);
            var existedStage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);

            var stage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);
            var existedStage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);

            var stage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);
            var existedStage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);

            var newStage = DataTest.CreateStage(
                    nameFromat: $"stage_4",
                    keyFormat: $"stageKey_4",
                    enable: true,
                    isDoneStage: false);

            model.Stages.Add(stage1);
            model.Stages.Add(stage2);
            model.Stages.Add(stage3);

            existedModel.Stages.Add(existedStage1);
            existedModel.Stages.Add(existedStage2);
            existedModel.Stages.Add(existedStage3);
            existedModel.Stages.Add(newStage);

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> ExistedSimpleFormModelWithThreeExistedStagesAndNewDoneStage()
        {
            var guid = Guid.NewGuid();
            var name = $"Auto_gen_Form_test_name_{guid:N}";
            var code = $"Auto_gen_Form_test_code_{guid:N}";


            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);
            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            var stage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);
            var existedStage1 = DataTest.CreateStage(
                    nameFromat: $"stage_1",
                    keyFormat: $"stageKey_1",
                    enable: true,
                    isDoneStage: false);

            var stage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);
            var existedStage2 = DataTest.CreateStage(
                    nameFromat: $"stage_2",
                    keyFormat: $"stageKey_2",
                    enable: true,
                    isDoneStage: false);

            var stage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);
            var existedStage3 = DataTest.CreateStage(
                    nameFromat: $"stage_3",
                    keyFormat: $"stageKey_3",
                    enable: true,
                    isDoneStage: true);

            var newStage = DataTest.CreateStage(
                    nameFromat: $"stage_4",
                    keyFormat: $"stageKey_4",
                    enable: true,
                    isDoneStage: true);

            model.Stages.Add(stage1);
            model.Stages.Add(stage2);
            model.Stages.Add(stage3);

            existedModel.Stages.Add(existedStage1);
            existedModel.Stages.Add(existedStage2);
            existedModel.Stages.Add(existedStage3);
            existedModel.Stages.Add(newStage);

            return new[]
            {
                new object[] { model, existedModel },
            };
        }

        public static IEnumerable<object[]> SimpleFormModelWithEmptyExtendedUserKey()
        {
            var model = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName();

            model.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            var property = DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]);

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(group));

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(existedModel.PropertyGroups[0]));

            existedModel.Properties.Add(
                DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(dto =>
                {
                    dto.Group = existedModel.PropertyGroups[0];
                    dto.NameFormat = "secondTextProperty";
                    dto.UserKeyFormat = "secondTextProperty";
                }));

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));


            var existedModel = DataTest.CreateAnCrmFormWithNewGeneratedCodeAndName(nameFromat: name, codeFromat: code);

            existedModel.PropertyGroups.Add(DataTest.CreateASimplePropertyGroup());

            existedModel.Properties.Add(
                DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(dto =>
                {
                    dto.Group = existedModel.PropertyGroups[0];
                    dto.NameFormat = "secondTextProperty";
                    dto.UserKeyFormat = "secondTextProperty";
                }));

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(model.PropertyGroups[0]));

            model.Properties.Add(
                DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>(dto =>
                {
                    dto.Group = model.PropertyGroups[0];
                    dto.NameFormat = "SecondTextProperty";
                }));

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

            model.Properties.Add(DataTest.CreateExtendedPropertyWithDefaultDto<TextExtendedPropertyModel>());

            return new[]
            {
                new object[] { model },
            };
        }
    }
}
