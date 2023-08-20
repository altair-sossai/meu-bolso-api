using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Infraestrutura.Pagination;

public class PaginationResult<T>
{
    public List<T>? Items { get; init; }
    public int TotalItems { get; init; }
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool HasPreviousPage => CurrentPage > 1;
    public int? PreviousPage => HasPreviousPage ? CurrentPage - 1 : null;
    public bool HasNextPage => TotalPages > CurrentPage;
    public int? NextPageIndex => HasNextPage ? CurrentPage + 1 : null;

    public static async Task<PaginationResult<T>> GetPaginationResultAsync(IQueryable<T> queryable, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var paginationResult = new PaginationResult<T>
        {
            Items = await queryable.Skip(skip).Take(pageSize).ToListAsync(),
            TotalItems = await queryable.CountAsync(),
            CurrentPage = page,
            PageSize = pageSize
        };

        return paginationResult;
    }
}