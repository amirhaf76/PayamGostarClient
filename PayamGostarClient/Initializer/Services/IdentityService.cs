using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class IdentityService : BaseInitService<CrmIdentityModel>
    {
        private IEnumerable<ProfileTypeGetResultDto> _profiles;

        internal IdentityService(CrmIdentityModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient, IInitServiceAbstractFactory factory) : base(intendedCrmObject, payamGostarApiClient, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var clientApi = CrmObjectTypeApi.IdentityApi;

            await InitializeProfileTypes();

            var identityCreationResult = await clientApi.CreateAsync(IntendedCrmObject.ToDtoBy(GetProfileGuid));

            return identityCreationResult.Result.Id;
        }

        private async Task InitializeProfileTypes()
        {
            if (_profiles != null)
            {
                return;
            }

            var clientApi = CrmObjectTypeApi.IdentityApi;

            var profiles = await clientApi.GetProfileTypeAsync();

            _profiles = profiles.Result;
        }

        private Guid GetProfileGuid(Gp_ProfileType profileType)
        {
            return
                _profiles
                    .Where(p => p.ProfileTypeIndex == (int)profileType)
                    .FirstOrDefault()?.Id ?? throw new ProfileTypeNotFoundException($"ProfileType: '{profileType}'");
        }
    }

}
