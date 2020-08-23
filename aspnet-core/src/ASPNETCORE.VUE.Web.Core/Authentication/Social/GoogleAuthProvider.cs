using ASPNETCORE.VUE.Authentication.External;
using ASPNETCORE.VUE.Models.Social;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.VUE.Authentication.Social
{
    class GoogleAuthProvider : ExternalAuthProviderApiBase
    {
        private static readonly HttpClient Client = new HttpClient();
        public const string Name = "GOOGLE";

        public override async Task<ExternalAuthUserInfo> GetUserInfo(string id_token)
        {
            //get userinfo
            try
            {
                var uri = "https://oauth2.googleapis.com/tokeninfo";

                var parameters = new Dictionary<string, string>()
                {
                    { "id_token", id_token }
                };

                uri = QueryHelpers.AddQueryString(uri, parameters);

                var userInfoResponse = await SendAsync(HttpMethod.Get ,uri);
                var content = await userInfoResponse.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<GoogleUserData>(content);

                if (!string.IsNullOrEmpty(userInfo.Error))
                {
                    throw new ArgumentException(string.Format("login_failure", userInfo.ErrorDescription));
                }

                return new ExternalAuthUserInfo
                {
                    Name = userInfo.FirstName,
                    EmailAddress = userInfo.Email,
                    Surname = userInfo.LastName,
                    Provider = Name,
                    ProviderKey = userInfo.Id
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, object content = null)
        {
            var requestMessage = new HttpRequestMessage(method, uri);
            if (content != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
            }

            return Client.SendAsync(requestMessage);
        }
    }
}
