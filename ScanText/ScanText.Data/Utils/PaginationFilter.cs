
using System.Collections.Generic;

namespace ScanText.Data.Utils
{
    public class PaginationFilter<T> where T : class
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; } = 5;
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Pages { get; set; }

    }
}
