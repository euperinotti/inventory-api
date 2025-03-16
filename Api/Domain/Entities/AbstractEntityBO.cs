namespace InventoryApi.Domain.Entities;

public abstract class AbstractEntityBO
{
    private long? _id;
    private DateTime _createdAt;
    private DateTime _updatedAt;

    protected AbstractEntityBO(long? id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public long? Id
    {
        get => _id;
        private set => _id = value;
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        private set => _createdAt = value;
    }

    public DateTime UpdatedAt
    {
        get => _updatedAt;
        private set => _updatedAt = value;
    }

    public void UpdatedAtNow()
    {
        UpdatedAt = DateTime.Now;
    }
}
