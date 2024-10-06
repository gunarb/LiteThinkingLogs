using Domain;

namespace Application
{
    public interface IRepository<T>
    {
        Task<LogEntity> CreateLogAsync(LogEntity logEntity);
        //Task CreateLogAsync(LogEntity logEntity);
        Task <IEnumerable<T>> GetAllAsync();
    }
}
