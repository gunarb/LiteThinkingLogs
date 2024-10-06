using Domain;

namespace Application
{
    public class CreateLogUseCase<TDTO>
    {
        private readonly IRepository<LogEntity> _logRepository;
        private readonly IMapper<TDTO, LogEntity> _mapper;

        public CreateLogUseCase(IRepository<LogEntity> logRepository, 
            IMapper<TDTO, LogEntity> mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO dto)
        {
            LogEntity logEntity = _mapper.ToMap(dto)
                ?? throw new Exception("There is an error creating the log");

            logEntity.LogId = new Guid(Guid.NewGuid().ToString());
            logEntity.CreateDate = DateTime.UtcNow;

            await _logRepository.CreateLogAsync(logEntity);
        }
    }
}