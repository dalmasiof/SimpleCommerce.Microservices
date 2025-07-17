namespace Sharedkernel.Interfaces
{
    public interface IBaseRepository <T> : IBaseCrud<T> where T : class
    {
    }
}
