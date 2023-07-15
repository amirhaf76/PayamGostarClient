using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncTest
{
    internal class CrmObjectsCode
    {
        public const string PAYMENT = "pardakht_100";
        public const string RECEIPT = "daryaft_100";

        public const string INVOICE = "s_100";
        public const string PURCHASE_INVOICE = "fkh_100";
        public const string RETURN_PURCHASE_INVOICE = "bkh_100";
        public const string RETURN_SALE_INVOICE = "fb_100";
        public const string QUOTE = "p_100";

        public const string PERSON_IDENTITY = "person_100";
        public const string ORGANIZATION_IDENTITY = "organization_100";

    }

    internal class CrmObjectsName
    {
        public const string PAYMENT = "پرداخت";
        public const string RECEIPT = "دریافت";

        public const string INVOICE = "فاکتور فروش";
        public const string PURCHASE_INVOICE = "فاکتور خرید";
        public const string RETURN_PURCHASE_INVOICE = "فاکتور برگشت از خرید";
        public const string RETURN_SALE_INVOICE = "فاکتور برگشت از فروش";
        public const string QUOTE = "پیش فاکتور";

        public const string PERSON_IDENTITY = "مخاطب حقیقی";
        public const string ORGANIZATION_IDENTITY = "مخاطب حقوقی";

    }

    internal class CrmObjectsNumberingTemplatePrefix
    {
        public const string PAYMENT = "100-{____(SHYY)}/{*(DP:510)}-{__(DLP:pr)}-{*(AN)}";
        public const string RECEIPT = "100-{____(SHYY)}/{*(DP:510)}-{__(DLP:dr)}-{*(AN)}";

        public const string INVOICE = "100-{____(SHYY)}/{*(AN)}";
        public const string PURCHASE_INVOICE = "100-{____(SHYY)}/{*(FP:6)}-{*(AN)}";
        public const string RETURN_PURCHASE_INVOICE = "100-{____(SHYY)}/{*(DP:510)}-{__(DLP:dr)}-{*(AN)}";
        public const string RETURN_SALE_INVOICE = "100-{____(SHYY)}/{*(AN)}";
        public const string QUOTE = "100-{____(SHYY)}/{*(AN)}";

        public const string PERSON_IDENTITY = "100-{*(AN)}";
        public const string ORGANIZATION_IDENTITY = "100-{*(AN)}";

    }

    internal class CrmObjectsNumberingTemplateName
    {
        public const string PAYMENT = "پرداخت سپیدار";
        public const string RECEIPT = "دریافت سپیدار";

        public const string INVOICE = "فاکتور سپیدار";
        public const string PURCHASE_INVOICE = "فاکتور خرید سپیدار";
        public const string RETURN_PURCHASE_INVOICE = "فاکتور برگشت از خرید سپیدار";
        public const string RETURN_SALE_INVOICE = "فاکتور برگشت از فروش سپیدار";
        public const string QUOTE = "پیش فاکتور سپیدار";

        public const string PERSON_IDENTITY = "هویت سپیدار";
        public const string ORGANIZATION_IDENTITY = "هویت سپیدار";

    }

    internal class CrmObjectsGeneralGroupName
    {
        public const string SYNC = "فیلدهای همگامساز";
        public const string PAYMENT = "گروه فیلد های پرداخت";
        public const string RECEIPT = "گروه فیلد های دریافت";
        public const string QUOTE = "فیلد های پیش فاکتور";
    }
}
