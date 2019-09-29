using Newtonsoft.Json;

namespace Draco.UserManagement.DataProvider.Models
{
    public class User
    {
        public int Id { get; set; }
        [JsonProperty("first")]
        public string FirstName { get; set; }
        [JsonProperty("last")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("gender")]

        [JsonConverter(typeof(GenderJsonConverter))]
        public Gender Gender { get; set; }
    }
}
