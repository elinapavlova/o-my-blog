using OMyBlog.Domain.Entities;

namespace OMyBlog.Domain.Contracts.Repositories;

public interface IPersonRepository : IBaseRepository<PersonEntity>
{
    Task<PersonEntity?> UpdateOne(PersonEntity entity);
}