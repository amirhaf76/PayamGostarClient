using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using System.Collections.Generic;

namespace PayamGostarClient.InitServiceModels.Comparers
{
    public class ResourceValueEqualityComparer : IEqualityComparer<ResourceValue>
    {
        private static ResourceValueEqualityComparer s_singletonObj;

        private ResourceValueEqualityComparer()
        {

        }

        public static ResourceValueEqualityComparer GetInstance()
        {
            if (s_singletonObj == null)
            {
                s_singletonObj = new ResourceValueEqualityComparer();
            }

            return s_singletonObj;
        }

        public bool Equals(ResourceValue x, ResourceValue y)
        {
            return x.Value == y.Value && x.LanguageCulture == y.LanguageCulture;
        }

        public int GetHashCode(ResourceValue obj)
        {
            int hash = 17;
            hash = hash * 23 + obj.Value?.GetHashCode() ?? 0;
            hash = hash * 23 + obj.LanguageCulture?.GetHashCode() ?? 0;

            return hash;
        }
    }
}
