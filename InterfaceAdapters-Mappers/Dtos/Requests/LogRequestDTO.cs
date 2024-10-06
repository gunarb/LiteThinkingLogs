namespace InterfaceAdapters_Mappers.Dtos.Requests
{
    public class LogRequestDTO
    {
        public Guid LogId { get; set; }
        public required string LogType { get; set; }
        public string? LogDescription { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
