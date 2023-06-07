namespace EFDemo.Models
{
    using System.Text.Json.Serialization;
    public class Waluta
    {
        [JsonPropertyName("code")]
        public string Name { get; set; }
        [JsonPropertyName("currency")]
        public string Info { get; set; }
        [JsonPropertyName("rates")]
        public List<Rates> Rates { get; set; }
        //[JsonPropertyName("mid")]
        //public double war { get; set; }
    }
    public class Rates
    {
        [JsonPropertyName("mid")]
        public double war { get; set; }
    }
}
