namespace Academia10.Domain.Entity;

public class Base
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? RemovedDate { get; set; }
    public bool Removed { get; set; }


    public Base()
    {
        CreatedDate = DateTime.UtcNow;
        Removed = false;
    }

    public virtual void Create()
    {
        CreatedDate = DateTime.UtcNow;
        Removed = false;
    }

    public virtual void Update()
    {
        UpdatedDate = DateTime.UtcNow;
    }

    public virtual void Remove()
    {
        RemovedDate = DateTime.UtcNow;
        Removed = true;
    }
}
