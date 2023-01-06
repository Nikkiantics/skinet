using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIn, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIn = pageIn;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIn {get; set;}
        public int PageSize {get; set;}
        public int Count {get; set;}
        public IReadOnlyList<T> Data {get; set;}
    }
}