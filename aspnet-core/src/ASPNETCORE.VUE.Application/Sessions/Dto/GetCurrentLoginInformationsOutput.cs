using ASPNETCORE.VUE.Users.Dto;

namespace ASPNETCORE.VUE.Sessions.Dto
{
    public class GetCurrentLoginInformationsOutput
    {
        public ApplicationInfoDto Application { get; set; }

        public UserDto User { get; set; }

        public TenantLoginInfoDto Tenant { get; set; }
    }
}
