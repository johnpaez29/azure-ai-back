using ApiAzureAi.Model.Requests;
using ApiAzureAi.Model.Responses;

namespace ApiAzureAi.Service.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResponse> GetSearch(SearchRequest filter);
    }
}
