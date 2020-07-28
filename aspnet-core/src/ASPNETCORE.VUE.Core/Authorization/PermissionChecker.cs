using Abp.Authorization;
using ASPNETCORE.VUE.Authorization.Roles;
using ASPNETCORE.VUE.Authorization.Users;

namespace ASPNETCORE.VUE.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
