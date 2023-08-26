using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Exceptions;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Services
{
    public class IdentityService : BaseInitService<CrmIdentityModel>
    {
        private IEnumerable<ProfileTypeGetResultDto> _profiles;

        internal IdentityService(CrmIdentityModel intendedCrmObject, IInitServiceAbstractFactory factory) : base(intendedCrmObject, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var clientApi = CrmObjectTypeApi.IdentityApi;

            await InitializeProfileTypes();

            var identityCreationResult = await clientApi.CreateAsync(IntendedCrmObject.ToDtoBy(GetProfileGuid));

            return identityCreationResult.Id;
        }

        private async Task InitializeProfileTypes()
        {
            if (_profiles != null)
            {
                return;
            }

            var clientApi = CrmObjectTypeApi.IdentityApi;

            var profiles = await clientApi.GetProfileTypeAsync();

            _profiles = profiles;
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
