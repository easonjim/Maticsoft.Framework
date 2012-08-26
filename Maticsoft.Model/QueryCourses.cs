using System;

namespace Maticsoft.Model
{
    [Serializable]
    public class QueryCourses
    {
        public QueryCourses()
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

        private int? _courseid;

        /// <summary>
        /// 课程编号
        /// </summary>
        public int? CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        private int? _coursetypes;

        /// <summary>
        /// 课程类型：0 普通课程 1：组织课程
        /// </summary>
        public int? CourseTypes
        {
            set { _coursetypes = value; }
            get { return _coursetypes; }
        }

        private int? _moduleid;

        /// <summary>
        /// 小节ID
        /// </summary>
        public int? ModuleId
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }

        private int? _categoryid;

        /// <summary>
        /// 课程类别
        /// </summary>
        public int? CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
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

        private string _modulename;

        /// <summary>
        /// 小节名称
        /// </summary>
        public string ModuleName
        {
            get { return _modulename; }
            set { _modulename = value; }
        }

        private int? _searchType;

        /// <summary>
        /// 搜索类型
        /// </summary>
        public int? SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
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