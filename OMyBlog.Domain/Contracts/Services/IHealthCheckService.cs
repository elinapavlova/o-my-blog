namespace OMyBlog.Domain.Contracts.Services;

public interface IHealthCheckService
{
    Task<bool> PingDb();
    Task<bool> PingElasticSearch();
}