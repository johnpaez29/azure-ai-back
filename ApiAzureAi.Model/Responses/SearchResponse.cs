using System.Text.Json.Serialization;

namespace ApiAzureAi.Model.Responses
{
    public class SearchResponse
    {
        [JsonPropertyName("@odata.context")]
        public string ODataContext { get; set; } = string.Empty;

        [JsonPropertyName("@odata.count")]
        public int ODataCount { get; set; }

        [JsonPropertyName("value")]
        public List<SearchDocument> Value { get; set; } = [];

        [JsonPropertyName("@search.facets")]
        public Dictionary<string, List<object>> SearchFacets { get; set; } = [];
    }

    public class Location
    {
        [JsonPropertyName("value")]
        public string? Value { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }

    }
    public class SearchDocument
    {
        [JsonPropertyName("@search.score")]
        public double SearchScore;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("metadata_storage_path")]
        public string MetadataStoragePath { get; set; } = string.Empty;

        [JsonPropertyName("people")]
        public List<string> People { get; set; } = [];

        [JsonPropertyName("locations")]
        public List<string> Locations { get; set; } = [];

        [JsonPropertyName("organizations")]
        public List<string> Organizations { get; set; } = [];

        [JsonPropertyName("keyphrases")]
        public List<string> KeyPhrases { get; set; } = [];

        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("merged_content")]
        public string MergedContent { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public List<string> Text { get; set; } = [];

        [JsonPropertyName("layoutText")]
        public List<string> LayoutText { get; set; } = [];
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("Category")]
        public string Category { get; set; } = string.Empty;
        [JsonPropertyName("Description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("Url")]
        public string Url { get; set; } = string.Empty;
    }
}

