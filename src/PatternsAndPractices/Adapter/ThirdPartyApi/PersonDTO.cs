using Newtonsoft.Json;

namespace PatternsAndPractices.Adapter.ThirdPartyApi
{
    public class PersonDTO
    {
        [JsonProperty("name")]
        public string CharacterName { get; set; }
        [JsonConverter(typeof(GenderConverter))]
        public Gender Gender { get; set; }
    }

}
