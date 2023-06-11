using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels
{
    public class CrmFormModel : BaseCRMModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Form;

        public PublicFormLogicModel PublicForm { get; set; }

        public bool LimitAccessToProcessUsers { get; set; }

        public bool ViewOnlyToOwner { get; set; }

        public bool ShowToCustomer { get; set; }

        public bool AssignCustomerNumberOnApprove { get; set; }

        public bool CreateByCustomer { get; set; }

        public bool CustomerCanViewExtendedProps { get; set; }


        public string WebhookAddress { get; set; }


        public string Prefix { get; set; }

        public string Postfix { get; set; }

        public int StartFrom { get; set; }

        public int DigitCount { get; set; }

    }

    public class PublicFormLogicModel
    {
        public bool FlushFormAfterSave { get; set; }

        public bool IsAutoSubject { get; set; }

        public bool SubmitMessage { get; set; }

        public string RedirectAfterSuccessUrl { get; set; }
    }
}
