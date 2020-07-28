using Abp.AutoMapper;
using ASPNETCORE.VUE.Authentication.External;

namespace ASPNETCORE.VUE.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
