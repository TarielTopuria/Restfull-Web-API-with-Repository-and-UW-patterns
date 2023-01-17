namespace Restfull_Web_API_with_Repository_and_UW_patterns.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid Id);
        Task<bool> Add(T entity);
        Task<bool> Delete (Guid Id);
        Task<bool> Upsert(T entity);
    }
}
