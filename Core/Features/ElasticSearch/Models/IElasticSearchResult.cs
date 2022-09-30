namespace Core.Features.ElasticSearch.Models;

public interface IElasticSearchResult
{
    bool Success { get; }
    string Message { get; }
}