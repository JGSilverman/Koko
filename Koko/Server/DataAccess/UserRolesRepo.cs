using Microsoft.AspNetCore.Identity;
using Koko.Server.Domain;

namespace Koko.Server.DataAccess
{
    public class UserRolesRepo
    {
        private readonly UserManager<AppUser> userManager;

        public UserRolesRepo(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IList<string>> GetUserRoles(AppUser user)
        {
            return await this.userManager.GetRolesAsync(user);
        }
    }
}
