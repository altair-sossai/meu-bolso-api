using MeuBolso.Infraestrutura.QueryCommands;

namespace MeuBolso.Infraestrutura.Pagination;

public class PaginationCommand<T, TQueryCommand>
    where TQueryCommand : IQueryCommand<T>, new()
{
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 5_000;
    private const int MaxPageSize = 10_000;

    private int _page = DefaultPage;
    private int _pageSize = DefaultPageSize;

    public TQueryCommand? Filters { get; set; } = new();

    public int Page
    {
        get => _page;
        set => _page = Math.Max(1, value);
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(Math.Max(1, value), MaxPageSize);
    }

    public async Task<PaginationResult<T>> GetPaginationResultAsync(IQueryable<T> queryable)
    {
        queryable = Filters?.Apply(queryable) ?? queryable;

        return await PaginationResult<T>.GetPaginationResultAsync(queryable, Page, PageSize);
    }
}