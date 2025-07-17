namespace Sharedkernel.Interfaces
{
    public interface IBaseService<T> : IBaseCrud<T> where T : class
    {        
    }
}
