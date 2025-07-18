namespace Sharedkernel.Interfaces
{
    public interface IBaseMapper <TDto, TEntity>
    {
        TEntity ToEntity(TDto dto);
        TDto ToDto(TEntity entity);
    }
}
