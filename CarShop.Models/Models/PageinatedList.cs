using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Models.Models
{
    public class PageinatedList<T> : List<T>
    {
        public int PageIndex{ get; set; }
        public int TotalPages { get; set; }

        public PageinatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PageinatedList<T> Create(List<T> source , 
                int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex-1)* pageSize).Take(pageSize).ToList();

            return new PageinatedList<T>(items,count, pageIndex, pageSize);
        }
    }
}
