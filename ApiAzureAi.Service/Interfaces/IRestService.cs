namespace ApiAzureAi.Service.Interfaces
{
    public interface IRestService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, IDictionary<string, string>? headers = null);
    }
}
