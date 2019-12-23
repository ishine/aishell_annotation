using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PagedList
{
    /// <summary>
    /// Container for extension methods designed to simplify the creation of instances of <see cref="PagedList{T}"/>.
    /// </summary>
    public static class PagedListExtensions
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="superset">可查询列表</param>
        /// <param name="pageNumber">当面页码，从1开始</param>
        /// <param name="pageSize">每页大小,默认30</param>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> superset, int pageNumber = 1, int pageSize = 30)
        {
            return new PagedList<T>(superset, pageNumber, pageSize);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="superset">可查询列表</param>
        /// <param name="pageNumber">当面页码，从1开始</param>
        /// <param name="pageSize">每页大小,默认30</param>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> superset, int pageNumber = 1, int pageSize = 30)
        {
            return Task.Run<IPagedList<T>>(() => new PagedList<T>(superset, pageNumber, pageSize));
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="superset">可查询列表</param>
        /// <param name="pageNumber">当面页码，从1开始</param>
        /// <param name="pageSize">每页大小,默认30</param>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> superset, int pageNumber = 1, int pageSize = 30)
        {
            return new PagedList<T>(superset, pageNumber, pageSize);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="superset">可查询列表</param>
        /// <param name="pageNumber">当面页码，从1开始</param>
        /// <param name="pageSize">每页大小,默认30</param>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, int pageNumber = 1, int pageSize = 30)
        {
            return Task.Run<IPagedList<T>>(() => new PagedList<T>(superset, pageNumber, pageSize));
        }

        /// <summary>
        /// Splits a collection of objects into n pages with an (for example, if I have a list of 45 shoes and say 'shoes.Split(5)' I will now have 4 pages of 10 shoes and 1 page of 5 shoes.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="superset">The collection of objects to be divided into subsets.</param>
        /// <param name="numberOfPages">The number of pages this collection should be split into.</param>
        /// <returns>A subset of this collection of objects, split into n pages.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> superset, int numberOfPages)
        {
            return superset
                .Select((item, index) => new { index, item })
                .GroupBy(x => x.index % numberOfPages)
                .Select(x => x.Select(y => y.item));
        }

        /// <summary>
        /// Splits a collection of objects into an unknown number of pages with n items per page (for example, if I have a list of 45 shoes and say 'shoes.Partition(10)' I will now have 4 pages of 10 shoes and 1 page of 5 shoes.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="superset">The collection of objects to be divided into subsets.</param>
        /// <param name="pageSize">The maximum number of items each page may contain.</param>
        /// <returns>A subset of this collection of objects, split into pages of maximum size n.</returns>
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> superset, int pageSize)
        {
            if (superset.Count() < pageSize)
                yield return superset;
            else
            {
                var numberOfPages = Math.Ceiling(superset.Count() / (double)pageSize);
                for (var i = 0; i < numberOfPages; i++)
                    yield return superset.Skip(pageSize * i).Take(pageSize);
            }
        }

        /// <summary>
        /// 转换分页元素类型 IPagedList~TEntity  -> IPagedList~TDto
        /// </summary>
        /// <typeparam name="TSrc"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="pagedList"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static IPagedList<TDest> Cast<TSrc, TDest>(this IPagedList<TSrc> pagedList, Func<TSrc, TDest> converter)
        {
            var dst = new StaticPagedList<TDest>(pagedList.Items.Select(converter), pagedList);
            return dst;
        }
    }
}