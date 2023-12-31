﻿using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using PayamGostarClient.ApiProvider;
using System.Linq;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypePaymentApiClientExtension
    {
        public static CrmObjectTypePaymentCreateRequestVM ToVM(this CrmObjectTypePaymentCreateRequestDto dto)
        {
            return new CrmObjectTypePaymentCreateRequestVM().FillCrmObjectTypePaymentCreateRequestVM(dto);
        }

        public static TTo FillCrmObjectTypePaymentCreateRequestVM<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : CrmObjectTypePaymentCreateRequestVM
            where TFrom : CrmObjectTypeBasePaymentCreateRequestDto
        {
            to.NumberingTemplateId = from.NumberingTemplateId;
            to.NeedApproval = from.NeedApproval;
            to.NeedNumbering = from.NeedNumbering;
            to.ChangeToStatePendingOnUpdate = from.ChangeToStatePendingOnUpdate;
            to.CustomerPaymentType = from.CustomerPaymentType.Cast<Gp_PaymentType>();
            to.Signature = from.Signature?.ToVM();

            return to.FillBaseCrmObjectTypeCreateRequestVM(from);
        }
    }


}
