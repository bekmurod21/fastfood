namespace FastFood.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set;}
    public DateTime DeletedAt { get; set; }
    public long? CreatedBy { get; set; }
}
