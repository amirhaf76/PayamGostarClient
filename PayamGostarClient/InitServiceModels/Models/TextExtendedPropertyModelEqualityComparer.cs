using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Models
{
    public interface ICheckExtendedProperty<T>
        where T : BaseExtendedPropertyModel
    {
        void Checks(T x, T y);
    }

    internal abstract class BaseExtendedPropertyModelEqualityComparer<T> : ICheckExtendedProperty<T>
        where T : BaseExtendedPropertyModel
    {
        protected static void CheckFieldMatching<TField>(TField first, TField second)
        {
            ModelChecker.CheckFieldMatching(first, second);
        }

        public void ChecksBase(BaseExtendedPropertyModel x, BaseExtendedPropertyModel y)
        {
            CheckFieldMatching(x.Type, y.Type);
            CheckFieldMatching(x.UserKey, y.UserKey);
            CheckFieldMatching(x.IsRequired, y.IsRequired);
            CheckFieldMatching(x.DefaultValue, y.DefaultValue);

            if (!x.Name.CheckResourceValues(y.Name))
            {
                throw new MisMatchException();
            }

            if (!x.ToolTip.CheckResourceValues(y.ToolTip))
            {
                throw new MisMatchException();
            }
        }

        public abstract void Checks(T x, T y);
    }

    internal class TextExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<TextExtendedPropertyModel>
    {
        public override void Checks(TextExtendedPropertyModel x, TextExtendedPropertyModel y)
        {
            ChecksBase(x, y);
        }
    }
    internal class FormExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<FormExtendedPropertyModel>
    {
        public override void Checks(FormExtendedPropertyModel x, FormExtendedPropertyModel y)
        {
            ChecksBase(x, y);
        }
    }
    internal class DropDownListExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<DropDownListExtendedPropertyModel>
    {
        public override void Checks(DropDownListExtendedPropertyModel x, DropDownListExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            //foreach (var value in x.Values)
            //{
            //    if (!y.Values.Any(v => v.Value == value.Value))
            //    {
            //        throw new MisMatchException($"'{value}' does not exist in {{userKey: {x.UserKey}}} dropdown list!");
            //    }
            //}

           // counts !!!

        }
    }
    internal class UserExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<UserExtendedPropertyModel>
    {
        public override void Checks(UserExtendedPropertyModel x, UserExtendedPropertyModel y)
        {
            ChecksBase(x, y);


        }
    }
    internal class NumberExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<NumberExtendedPropertyModel>
    {
        public override void Checks(NumberExtendedPropertyModel x, NumberExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.MinDigits, y.MinDigits);
            CheckFieldMatching(x.MaxDigits, y.MaxDigits);
            CheckFieldMatching(x.MinValue, y.MinValue);
            CheckFieldMatching(x.MaxValue, y.MaxValue);
            CheckFieldMatching(x.DecimalDigits, y.DecimalDigits);
        }
    }
    internal class DepartmentExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<DepartmentExtendedPropertyModel>
    {
        public override void Checks(DepartmentExtendedPropertyModel x, DepartmentExtendedPropertyModel y)
        {
            ChecksBase(x, y);


        }
    }
    internal class PositionExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<PositionExtendedPropertyModel>
    {
        public override void Checks(PositionExtendedPropertyModel x, PositionExtendedPropertyModel y)
        {
            ChecksBase(x, y);


        }
    }
    internal class PersianDateExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<PersianDateExtendedPropertyModel>
    {
        public override void Checks(PersianDateExtendedPropertyModel x, PersianDateExtendedPropertyModel y)
        {
            ChecksBase(x, y);


        }
    }
    internal class LabelExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<LabelExtendedPropertyModel>
    {
        public override void Checks(LabelExtendedPropertyModel x, LabelExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.LabelText, y.LabelText);
            //CheckFieldMatching(x.ColorId, y.ColorId);
            //CheckFieldMatching(x.ShowTitleTypeIndex, y.ShowTitleTypeIndex);
            CheckFieldMatching(x.IconName, y.IconName);

        }
    }
    internal class CrmObjectMultiValueExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<CrmObjectMultiValueExtendedPropertyModel>
    {
        public override void Checks(CrmObjectMultiValueExtendedPropertyModel x, CrmObjectMultiValueExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.CrmObjectTypeIndex, y.CrmObjectTypeIndex);
            CheckFieldMatching(x.SubTypeId, y.SubTypeId);

            var yIds = y.ShowInGridProps.Select(p => p.Id);

            foreach (var idWrapper in x.ShowInGridProps)
            {
                if (!yIds.Contains(idWrapper.Id))
                {
                    throw new MisMatchException($"'{idWrapper.Id}' id is not exist in current existed property!");
                }
            }
        }
    }

}
