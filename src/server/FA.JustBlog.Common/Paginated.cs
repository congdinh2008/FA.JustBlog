using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Common
{
    public class Paginated<TEntity> : List<TEntity>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;


        public Paginated(List<TEntity> entities, long count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(entities);
        }

        public static async Task<Paginated<TEntity>> CreateAsync(IQueryable<TEntity> query,
            int pageIndex, int pageSize)
        {
            var count = await query.LongCountAsync();

            var entities = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new Paginated<TEntity>(entities, count, pageIndex, pageSize);
        }
    }
}

