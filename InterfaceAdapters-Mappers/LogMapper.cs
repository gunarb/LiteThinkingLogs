using Application;
using Domain;
using InterfaceAdapters_Mappers.Dtos.Requests;

namespace InterfaceAdapters_Mappers
{
    public class LogMapper : IMapper<LogRequestDTO, LogEntity>
    {
        public LogEntity ToMap(LogRequestDTO dto)
            => new()
            {
                LogId = dto.LogId,
                LogType = dto.LogType,
                LogDescription = dto.LogDescription,
                CreateDate = dto.CreateDate,
            };
    }
}
