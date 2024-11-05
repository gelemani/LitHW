using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface IEntityRepositoryBase<T> where T : EntityBase
{
    void Add (T entity);
    void Update (T entity);
    void Delete (T entity);
    List<T> GetEntities ();
    Student GetById(int id);
}