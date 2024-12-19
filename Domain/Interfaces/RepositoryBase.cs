using Domain.Entities;

namespace Domain.Interfaces;

public interface RepositoryBase<T> where T : EntityBase
{
    Task Add(T entityBase);

    Task<T> Read(int id);

    Task Delete(T entityBase);

    Task Update(T entityBase);

    Task<List<T>> List();

}
