using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PagedList
{
    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <remarks>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </remarks>
    /// <typeparam name="T">The type of object the collection should contain.</typeparam>
    /// <seealso cref="IEnumerable{T}"/>
    public interface IPagedList<T> : IPagedList
    {

        ///<summary>
        /// 当页个数
        ///</summary>
        int Count { get; }

        /// <summary>
        /// 分页后元素
        /// </summary>
        IList<T> Items { get; }

        ///<summary>
        /// Gets a non-enumerable copy of this paged list.
        ///</summary>
        ///<returns>A non-enumerable copy of this paged list.</returns>
        IPagedList GetMetaData();
    }

    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <remarks>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </remarks>
    public interface IPagedList
    {
        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// 元素总个数
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// 当前页码，1开始
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// 每页大小
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 是否有上页
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下页
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// 是否首页
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// 是否末页
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// 当前页第一个元素在总列表中的序号，从0开始
        /// </summary>
        int FirstItemOnPage { get; }

        /// <summary>
        /// 当前页最后一个元素在总列表中的序号，从0开始
        /// </summary>
        int LastItemOnPage { get; }
    }
}