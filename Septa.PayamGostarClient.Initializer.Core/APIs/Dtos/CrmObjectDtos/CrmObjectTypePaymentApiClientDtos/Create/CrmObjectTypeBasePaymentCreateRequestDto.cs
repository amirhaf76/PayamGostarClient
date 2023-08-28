using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create
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
