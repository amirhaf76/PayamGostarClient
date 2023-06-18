using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
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
        protected static void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            ModelChecker.CheckFieldMatching(first, second, errorMessage);
        }

        public void ChecksBase(BaseExtendedPropertyModel x, BaseExtendedPropertyModel y)
        {
            CheckFieldMatching(x.Type, y.Type, "BaseExtendedPropertyModel:Type -> ");
            CheckFieldMatching(x.UserKey, y.UserKey, "BaseExtendedPropertyModel:UserKey -> ");
            CheckFieldMatching(x.IsRequired, y.IsRequired, "BaseExtendedPropertyModel:IsRequired -> ");
            CheckFieldMatching(x.DefaultValue, y.DefaultValue, "BaseExtendedPropertyModel:DefaultValue -> ");

            if (!x.Name.CheckResourceValues(y.Name))
            {
                MisMatchException.Create(x.Name, y.Name);
            }

            if (!x.ToolTip.CheckResourceValues(y.ToolTip))
            {
                MisMatchException.Create(x.Name, y.Name);
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

            CheckFieldMatching(x.MinDigits, y.MinDigits, "NumberExtendedPropertyModel:MinDigits -> ");
            CheckFieldMatching(x.MaxDigits, y.MaxDigits, "NumberExtendedPropertyModel:MaxDigits -> ");
            CheckFieldMatching(x.MinValue, y.MinValue, "NumberExtendedPropertyModel:MinValue -> ");
            CheckFieldMatching(x.MaxValue, y.MaxValue, "NumberExtendedPropertyModel:MaxValue -> ");
            CheckFieldMatching(x.DecimalDigits, y.DecimalDigits, "NumberExtendedPropertyModel:DecimalDigits -> ");
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

            CheckFieldMatching(x.LabelText, y.LabelText, "LabelExtendedPropertyModel:LabelText -> ");
            //CheckFieldMatching(x.ColorId, y.ColorId);
            //CheckFieldMatching(x.ShowTitleTypeIndex, y.ShowTitleTypeIndex);
            CheckFieldMatching(x.IconName, y.IconName, "LabelExtendedPropertyModel:IconName -> ");

        }
    }
    internal class CrmObjectMultiValueExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<CrmObjectMultiValueExtendedPropertyModel>
    {
        public override void Checks(CrmObjectMultiValueExtendedPropertyModel x, CrmObjectMultiValueExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.CrmObjectTypeIndex, y.CrmObjectTypeIndex, "CrmObjectMultiValueExtendedPropertyModel:CrmObjectTypeIndex -> ");
            CheckFieldMatching(x.SubTypeId, y.SubTypeId, "CrmObjectMultiValueExtendedPropertyModel:SubTypeId -> ");

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

    internal class TimeExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<TimeExtendedPropertyModel>
    {
        public override void Checks(TimeExtendedPropertyModel x, TimeExtendedPropertyModel y)
        {
            ChecksBase(x, y);


        }
    }
    internal class CurrencyExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<CurrencyExtendedPropertyModel>
    {
        public override void Checks(CurrencyExtendedPropertyModel x, CurrencyExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.IsBalance, y.IsBalance, "CurrencyExtendedPropertyModel:IsBalance -> ");
        }
    }
    internal class FileExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<FileExtendedPropertyModel>
    {
        public override void Checks(FileExtendedPropertyModel x, FileExtendedPropertyModel y)
        {
            ChecksBase(x, y);

            CheckFieldMatching(x.MaxFileSize, y.MaxFileSize, "FileExtendedPropertyModel:MaxFileSize -> ");
            CheckFieldMatching(x.FileSizeTypeIndex, y.FileSizeTypeIndex, "FileExtendedPropertyModel:FileSizeTypeIndex -> ");

            foreach (var extension in x.Extensions)
            {
                if (!y.Extensions.Contains(extension))
                {
                    throw new MisMatchException($"'{extension}' id is not exist in current existed property!");
                }
            }
        }
    }
    internal class CheckboxExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<CheckboxExtendedPropertyModel>
    {
        public override void Checks(CheckboxExtendedPropertyModel x, CheckboxExtendedPropertyModel y)
        {
            ChecksBase(x, y);
        }
    }
    internal class AppointmentExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<AppointmentExtendedPropertyModel>
    {
        public override void Checks(AppointmentExtendedPropertyModel x, AppointmentExtendedPropertyModel y)
        {
            ChecksBase(x, y);
        }
    }
    internal class SecurityItemExtendedPropertyModelEqualityComparer : BaseExtendedPropertyModelEqualityComparer<SecurityItemExtendedPropertyModel>
    {
        public override void Checks(SecurityItemExtendedPropertyModel x, SecurityItemExtendedPropertyModel y)
        {
            ChecksBase(x, y);
        }
    }


}
