namespace ApiAzureAi.Model.AppSettings
{
    public class Endpoints
    {
        public IEnumerable<Url> Urls { get; set; } = [];
    }

    public class Url
    {
        public required string Method { get; set; }
        public required string Domain { get; set; }
        public required string Endpoint { get; set; }

        public required string Name { get; set; }

    }
}
