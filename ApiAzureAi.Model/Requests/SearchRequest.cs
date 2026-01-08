using System.Text.Json.Serialization;

namespace ApiAzureAi.Model.Requests
{
    public class SearchRequest
    {
        public string Search { get; set; } = "*";

        public string? Filter { get; set; }

        public int? Top { get; set; }

        public int? Skip { get; set; }

        public List<string>? Facets { get; set; }

        public bool? Count { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IndexName { get; set; } = "azureblob-image-index";

        public string? QueryType { get; set; }
        public string? SemanticConfiguration { get; set; }
        public string? Speller { get; set; }
        public string? QueryLanguage { get; set; }
    }
}
