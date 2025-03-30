namespace Retech.Core.Common;

public interface ISoftDelete<T>
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public T? DeletedBy { get; set; }
}
