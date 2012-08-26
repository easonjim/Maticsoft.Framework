using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Categories:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Categories
    {
        public Categories()
        { }

        #region Model

        private int _categoryid;
        private string _name;
        private int? _sequence;
        private int? _parentcategoryid;
        private int? _depth;
        private string _path;
        private string _description;
        private string _iconurl;
        private int? _status;
        private DateTime? _createddate;
        private int? _createduserid;
        private string _rewritename;

        /// <summary>
        /// 类别编码
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        /// <summary>
        /// 顺序
        /// </summary>
        public int? Sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
        }

        /// <summary>
        /// 父类别
        /// </summary>
        public int? ParentCategoryId
        {
            set { _parentcategoryid = value; }
            get { return _parentcategoryid; }
        }

        /// <summary>
        /// 层级
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }

        /// <summary>
        /// 类别路径
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }

        /// <summary>
        /// 类别描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 类别图片
        /// </summary>
        public string IconUrl
        {
            set { _iconurl = value; }
            get { return _iconurl; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }

        /// <summary>
        /// 创建者
        /// </summary>
        public int? CreatedUserID
        {
            set { _createduserid = value; }
            get { return _createduserid; }
        }

        /// <summary>
        /// 重写名
        /// </summary>
        public string RewriteName
        {
            set { _rewritename = value; }
            get { return _rewritename; }
        }

        #endregion Model
    }
}