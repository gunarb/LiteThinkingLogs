using Newtonsoft.Json;

namespace Domain
{
    public class LogEntity
    {
        [JsonProperty("id")]
        public Guid LogId { get; set; }
        
        [JsonProperty("type")]
        public required string LogType { get; set; }

        [JsonProperty("description")]
        public string? LogDescription { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreateDate { get; set; }
    }
}
