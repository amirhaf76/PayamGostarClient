using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels
{
    public class CrmFormModel : BaseCRMModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Form;

        public PublicFormLogicModel PublicForm { get; set; }


        public string Prefix { get; set; }

        public string Postfix { get; set; }

        public long? StartFrom { get; set; }

        public int? DigitCount { get; set; }


        public class PublicFormLogicModel
        {
            public bool FlushFormAfterSave { get; set; }

            public bool IsAutoSubject { get; set; }

            public string SubmitMessage { get; set; }

            public string RedirectAfterSuccessUrl { get; set; }
        }
    }

}
