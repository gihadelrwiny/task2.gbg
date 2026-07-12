using task21.Models;

namespace task21.Services
{
    public class BookService
    {
        public static IQueryable<book> ApplyFilter(IQueryable<book> q, BookQueryParams p)
        {
            if (p.MinPrice.HasValue) q = q.Where(s => s.Price >= p.MinPrice.Value);
            if (p.MaxPrice.HasValue) q = q.Where(s => s.Price <= p.MaxPrice.Value);
            if (!string.IsNullOrEmpty(p.Author)) q = q.Where(s => s.Author == p.Author);
            q = p.SortBy.ToLower() switch
            {
                "price" => p.SortDir == "desc" ? q.OrderByDescending(x => x.Price) : q.OrderBy(x => x.Price),
                "name" => p.SortDir == "desc" ? q.OrderByDescending(x => x.Name) : q.OrderBy(x => x.Name),
                _ => q.OrderBy(x => x.Id)
            };
            return q;
        }
        public static IQueryable<book> ApplyPagination(IQueryable<book> q, BookQueryParams p)
        {
            return q
                .Skip((p.PageNumber - 1) * p.PageSize)
                .Take(p.PageSize);
        }
    }
}
