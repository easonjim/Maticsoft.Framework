using System;

namespace Maticsoft.Model
{
    [Serializable]
    public class QueryUsers
    {
        public QueryUsers()
        { }

        private int? _userid;

        public int? Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private int? topCount;

        /// <summary>
        /// 查询记录条数
        /// </summary>
        public int? TopCount
        {
            get { return topCount; }
            set { topCount = value; }
        }

        private int? _status;

        /// <summary>
        /// 审核状态 0：未发布 ；1：已发布；2：未通过
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        private string _tags;

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        private bool isCount = true;
        private int pageIndex;
        private int pageSize = 4;
        private string sortBy = string.Empty;
        private string sortOrder = string.Empty;

        public bool IsCount
        {
            get
            {
                return this.isCount;
            }
            set
            {
                this.isCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        public string SortBy
        {
            get
            {
                return this.sortBy;
            }
            set
            {
                this.sortBy = value;
            }
        }

        public string SortOrder
        {
            get
            {
                return this.sortOrder;
            }
            set
            {
                this.sortOrder = value;
            }
        }
    }
}