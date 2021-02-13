using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Application.ViewModels
{
    public class PaginationFilterViewModel<T> where T : class
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; } = 5;
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Pages { get; set; }
    }
}
