#nullable enable

using System.Linq.Expressions;
using System.Reflection;
using MongoDB.Driver;
using OMyBlog.Domain.Attributes;
using OMyBlog.Domain.Entities;
using OMyBlog.Domain.Extensions;
using OMyBlog.Domain.Options;

namespace OMyBlog.Domain.Contracts.Repositories;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task Execute(Func<IMongoCollection<TEntity>, Task> func);
    Task<TResult> ExecuteWithResult<TResult>(Func<IMongoCollection<TEntity>, Task<TResult>> func);
    IQueryable<TEntity> AsQueryable();
    Task<IAsyncEnumerable<TEntity>> FilterBy(Expression<Func<TEntity, bool>> filterExpression);
    Task<TEntity?> GetById(Guid id);
    Task<TransactionContainer?> BeginTransaction();
}

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly IMongoCollection<TEntity> _collection;
    private readonly IMongoClient _client;

    public BaseRepository(DbOptions options)
    {
        _client = new MongoClient(options.ConnectionString);
        var database = _client.GetDatabase(options.DatabaseName);
        _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
    }

    protected static string? GetCollectionName(ICustomAttributeProvider entityType)
    {
        return ((BsonCollectionAttribute) entityType
                .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault()!)
            .CollectionName;
    }

    public async Task Execute(Func<IMongoCollection<TEntity>, Task> func)
    {
        await func(_collection);
    }

    public async Task<TResult> ExecuteWithResult<TResult>(Func<IMongoCollection<TEntity>, Task<TResult>> func)
    {
        var result = await func(_collection);
        return result;
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public async Task<IAsyncEnumerable<TEntity>> FilterBy(Expression<Func<TEntity, bool>> filterExpression)
    {
        var result = await _collection.FindAsync(filterExpression);
        return result.ToAsyncEnumerable();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        var result = await _collection.FindAsync(x => x.Id == id);
        return await result.FirstOrDefaultAsync();
    }

    public async Task<TransactionContainer?> BeginTransaction()
    {
        using var session = await _client.StartSessionAsync();
        session.StartTransaction();
        return new TransactionContainer(session);
    }
}