namespace Application
{
    public class GetLogsUseCase<T>
    {
        private readonly IRepository<T> _repository;
        
        public GetLogsUseCase(IRepository<T> repository) => _repository = repository;

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
