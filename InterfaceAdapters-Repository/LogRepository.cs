using Application;
using Domain;
using InterfaceAdapters_Data;
using Microsoft.Azure.Cosmos.Linq;

namespace InterfaceAdapters_Repository
{
    public class LogRepository : IRepository<LogEntity>
    {
        private readonly AppDbContext _dbContext;

        public LogRepository()
        {
            _dbContext = new AppDbContext();
        }
        
        /// <summary>
        /// Create a new log into cosmosdb
        /// </summary>
        /// <param name="logEntity">log entity object</param>
        /// <returns></returns>
        public async Task<LogEntity> CreateLogAsync(LogEntity logEntity)
        {
            var response = await _dbContext.LogContainer.CreateItemAsync(logEntity);
            return response.Resource;
        }

        /// <summary>
        /// Get all the logs from the cosmosdb
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LogEntity>> GetAllAsync()
        {
            var query = _dbContext.LogContainer.GetItemLinqQueryable<LogEntity>()
                .ToFeedIterator();

            var logs = new List<LogEntity>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                logs.AddRange(response);
            }

            return logs;
        }
    }
}
