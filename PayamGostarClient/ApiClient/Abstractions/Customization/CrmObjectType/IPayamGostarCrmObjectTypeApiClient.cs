﻿using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Models;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeApiClient
    {
        IPayamGostarCrmObjectTypeFormApiClient FormApi { get; }
        IPayamGostarCrmObjectTypeStageApiClient StageApi { get; }
        IPayamGostarCrmObjectTypeTicketApiClient TicketApi { get; }
        IPayamGostarCrmObjectTypeIdentityApiClient IdentityApi { get; }

        Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchAsync(CrmObjectTypeSearchRequestDto request);
    }
}