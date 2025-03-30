using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Retech.Shared.Models.Paginations;

namespace Retech.Application.Helpers;

public class PaginationItemModel
{
    public int CurrentPage { get; protected set; }
    public int TotalPages { get; protected set; }
    public int PageSize { get; protected set; }
    public int TotalCount { get; protected set; }
    public bool HasPrevious => CurrentPage > 0;
    public bool HasNext => CurrentPage < TotalPages - 1;
}

public class PaginationItem<T, D> : PaginationItemModel
{
    public PaginationItem(List<D> items, int count, int pageIndex, int pageSize) : base()
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        ListItem.AddRange(items);
    }

    public List<D> ListItem { get; set; } = new();

    public static PaginationItem<T, D> ToPagedList(IMapper mapper, List<T> source, int count, int? pageIndex = null!, int? pageSize = null!)
    {
        var paginationModel = new PaginationModel();
        var serviceProvider = new ServiceCollection().BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        if (configuration != null)
        {
            configuration.GetSection(nameof(PaginationModel)).Bind(paginationModel);
        }
        if (pageIndex.HasValue && pageSize.HasValue)
        {
            pageIndex = pageIndex == null || pageIndex.HasValue && pageIndex.Value < 0 ? 0 : pageIndex;
        }
        else
        {
            pageIndex = 0;
        }
        return new PaginationItem<T, D>(mapper.Map<List<D>>(source), count, (int)pageIndex, pageSize ?? paginationModel.PageSize);
    }
}
public class PaginationItem<T> : PaginationItemModel
{
    public PaginationItem(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        ListItem.AddRange(items);
    }
    public List<T> ListItem { get; set; } = new();

    public static PaginationItem<T> ToPagedList(IMapper mapper, List<T> source, int count, int? pageIndex = null!, int? pageSize = null!)
    {
        var paginationModel = new PaginationModel();
        var serviceProvider = new ServiceCollection().BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        if (configuration != null)
        {
            configuration.GetSection(nameof(PaginationModel)).Bind(paginationModel);
        }
        if (pageIndex.HasValue && pageSize.HasValue)
        {
            pageIndex = pageIndex == null || pageIndex.HasValue && pageIndex.Value < 0 ? 0 : pageIndex;
        }
        else
        {
            pageIndex = 0;
        }
        return new PaginationItem<T>(mapper.Map<List<T>>(source), count, (int)pageIndex, pageSize ?? paginationModel.PageSize);
    }
}
