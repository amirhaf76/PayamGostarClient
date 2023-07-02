using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using PayamGostarClient.ApiProvider;
using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create
{
    public abstract class CrmObjectTypeBasePaymentCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public int NumberingTemplateId { get; set; }

        public bool NeedApproval { get; set; }

        public bool NeedNumbering { get; set; }

        public bool ChangeToStatePendingOnUpdate { get; set; }

        public IEnumerable<Gp_PaymentType> CustomerPaymentType { get; set; }

        public CrmObjectTypeSignatureFilePathDto Signature { get; set; }

    }
}
