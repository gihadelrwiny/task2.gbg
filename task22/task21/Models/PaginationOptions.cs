using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace task21.Models
{
    public class PaginationOptions
    {
        public int DefaultPageSize { get; set; }
        public int MaxPageSize { get; set; }
    }
}
