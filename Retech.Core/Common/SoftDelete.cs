namespace Retech.Core.Common;
public class SoftDelete<T> : ISoftDelete<T>
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public T? DeletedBy { get; set; }
}
