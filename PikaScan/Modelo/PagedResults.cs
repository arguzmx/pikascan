using System.Collections.Generic;

namespace PikaScan.Modelo
{
    public class PagedResults<T> : Page
    {
        public PagedResults(int Index, int Size)
        {
            PageSize = Size;
            PageIndex = Index;
            TotalItems = 0;
            FilteredItems = 0;
        }
        public IEnumerable<T> Results { get; set; }

    }
}
