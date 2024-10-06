namespace Domain;

public class LogEntity
{
    public Guid LogId { get; set; }

    public required string Type { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreateDate { get; set; }
}
