using Newtonsoft.Json;

namespace ASPNETCORE.VUE.Models.Social
{
    internal class GoogleUserData
    {
        [JsonProperty("sub")]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        [JsonProperty("given_name")]
        public string FirstName { get; set; }
        [JsonProperty("family_name")]
        public string LastName { get; set; }
        public string Locale { get; set; }
        public string Picture { get; set; }
        [JsonProperty("exp")]
        public long ExpiresAt { get; set; }
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }

}
