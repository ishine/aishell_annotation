using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagedList
{/// <summary>
 /// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
 /// </summary>
 /// <remarks>
 /// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
 /// </remarks>
 /// <typeparam name = "T">The type of object the collection should contain.</typeparam>
 /// <seealso cref = "IPagedList{T}" />
 /// <seealso cref = "List{T}" />
    [Serializable]
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
    {
        /// <summary>
        /// 	The subset of items contained only within this one page of the superset.
        /// </summary>
        protected readonly List<T> Subset = new List<T>();

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        protected internal BasePagedList()
        {
        }

        /// <summary>
        /// 	Initializes a new instance of a type deriving from <see cref = "BasePagedList{T}" /> and sets properties needed to calculate position and size data on the subset and superset.
        /// </summary>
        /// <param name = "pageNumber">The one-based index of the subset of objects contained by this instance.</param>
        /// <param name = "pageSize">The maximum size of any individual subset.</param>
        /// <param name = "totalItemCount">The size of the superset.</param>
        protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = TotalItemCount > 0
                            ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                            : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            FirstItemOnPage = (PageNumber - 1) * PageSize + 1;
            var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
            LastItemOnPage = numberOfLastItemOnPage > TotalItemCount
                                 ? TotalItemCount
                                 : numberOfLastItemOnPage;
        }

        #region IPagedList<T> Members

        /// <summary>
        /// 本页元素个数
        /// </summary>
        public int Count => Subset.Count;

        public IList<T> Items => this.Subset;

        ///<summary>
        /// 获取分页页码数据
        ///</summary>
        public IPagedList GetMetaData() => new PagedListMetaData(this);



        #endregion
    }
}