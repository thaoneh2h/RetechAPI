namespace Retech.Shared.Models.Paginations;

public class PaginationModel
{
    public PaginationModel(int pageSize = 30)
    {
        this.PageSize = pageSize;
    }
    public int PageSize { get; private set; }
}
