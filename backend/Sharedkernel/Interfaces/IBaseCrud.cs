namespace Sharedkernel.Interfaces
{
    public interface IBaseCrud<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<IList<T>> GetAll();
        Task<bool> Delete(Guid guid);
        Task<T> GetById(Guid guid);
    }
}
