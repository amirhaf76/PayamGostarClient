using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Helpers;
using System.Linq;

namespace PayamGostarClient.Initializer.Comparers
{

    internal class GeneralExtendedPropertyModelEqualityComparer
    {
        protected static void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            ModelChecker.CheckFieldMatching(first, second, errorMessage);
        }

        public void Checks(BaseExtendedPropertyModel x, BaseExtendedPropertyModel y)
        {
            CheckFieldMatching(x.UserKey, y.UserKey, "BaseExtendedPropertyModel:UserKey -> ");
            CheckFieldMatching(x.Type, y.Type, "BaseExtendedPropertyModel:Type -> ");
        }
    }

}
