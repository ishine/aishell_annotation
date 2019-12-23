using System;
using System.Collections.Generic;
using System.Text;

namespace PagedList
{///<summary>
 /// Non-enumerable version of the PagedList class.
 ///</summary>
    [Serializable]
    public class PagedListMetaData : IPagedList
    {
        /// <summary>
        /// Protected constructor that allows for instantiation without passing in a separate list.
        /// </summary>
        protected PagedListMetaData()
        {
        }

        ///<summary>
        /// Non-enumerable version of the PagedList class.
        ///</summary>
        ///<param name="pagedList">A PagedList (likely enumerable) to copy metadata from.</param>
        public PagedListMetaData(IPagedList pagedList)
        {
            PageCount = pagedList.PageCount;
            TotalItemCount = pagedList.TotalItemCount;
            PageNumber = pagedList.PageNumber;
            PageSize = pagedList.PageSize;
            HasPreviousPage = pagedList.HasPreviousPage;
            HasNextPage = pagedList.HasNextPage;
            IsFirstPage = pagedList.IsFirstPage;
            IsLastPage = pagedList.IsLastPage;
            FirstItemOnPage = pagedList.FirstItemOnPage;
            LastItemOnPage = pagedList.LastItemOnPage;
        }

        #region IPagedList Members

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// 元素总个数
        /// </summary>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// 元素总个数
        /// </summary>
        public int PageNumber { get; protected set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// 是否有上页
        /// </summary>
        public bool HasPreviousPage { get; protected set; }

        /// <summary>
        /// 是否有下页
        /// </summary>
        public bool HasNextPage { get; protected set; }

        /// <summary>
        /// 是否首页
        /// </summary>
        public bool IsFirstPage { get; protected set; }

        /// <summary>
        /// 是否末页
        /// </summary>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        /// 当前页第一个元素在总列表中的序号，从0开始
        /// </summary>
        public int FirstItemOnPage { get; protected set; }

        /// <summary>
        /// 当前页最后一个元素在总列表中的序号，从0开始
        /// </summary>
        public int LastItemOnPage { get; protected set; }

        #endregion
    }
}