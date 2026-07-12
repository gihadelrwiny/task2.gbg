namespace task21.Models
{
    public class BookQueryParams:PaginationParams
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? InStock { get; set; }
        public string SortBy { get; set; } = "id";
        public string SortDir { get; set; } = "asc";
        public string?  Author { get; set; }


    }
}
