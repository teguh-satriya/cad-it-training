using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ListAsset.BusinessAccess.Authentication
{
    public partial class ApplicationPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private AssetIdentityDbContext identityContext;

        public ApplicationPrincipalFactory(AssetIdentityDbContext identityContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
            this.identityContext = identityContext;
        }
        partial void OnCreatePrincipal(ClaimsPrincipal principal, ApplicationUser user);

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            this.OnCreatePrincipal(principal, user);

            return principal;
        }
    }
}
