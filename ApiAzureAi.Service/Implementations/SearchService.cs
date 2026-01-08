using ApiAzureAi.Model;
using ApiAzureAi.Model.AppSettings;
using ApiAzureAi.Model.Requests;
using ApiAzureAi.Model.Responses;
using ApiAzureAi.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace ApiAzureAi.Service.Implementations
{
    public class SearchService(IRestService restService, 
        IOptions<Endpoints> optionsEndpoint,
        IOptions<Azure> optionsAzure
        ) : ISearchService
    {
        private readonly Endpoints endpoints = optionsEndpoint.Value;
        public async Task<SearchResponse> GetSearch(SearchRequest filter)
        {

            SearchRequest searchRequest = filter;

            string endpoint = endpoints.Urls.FirstOrDefault(url => 
            url.Name == EndpointsApi.NameGetData)?
                .Endpoint?.Replace("{index}", filter.IndexName) ?? throw new Exception("Error getting Endpoint service");

            filter.IndexName = null;
            if (filter.Search?.Split(" ")?.Length > 3)
            {
                filter.QueryType = "semantic";
                filter.SemanticConfiguration = "default";
            }
            filter.QueryLanguage = "en-us";
            filter.Speller = "lexicon";

            var headers = new Dictionary<string, string>
            {
                { "api-key", optionsAzure.Value.ApiKey }
            };
            return await restService.PostAsync<SearchRequest, SearchResponse>(endpoint, searchRequest, headers) ?? new();
        }
    }
}
