using System.Collections.Generic;

namespace ASPNETCORE.VUE.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
