namespace InventoryManager.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAtUtc { get; protected set; }
    public DateTime UpdatedAtUtc { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAtUtc = DateTime.UtcNow;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void SetUpdatedAt()
    {
        UpdatedAtUtc = DateTime.UtcNow;
    }
}