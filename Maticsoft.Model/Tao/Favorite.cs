using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Favorite:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Favorite
    {
        public Favorite()
        { }

        #region Model

        private int _favoriteid;
        private int? _courseid;
        private int? _moduleid;
        private int? _userid;
        private string _tags;
        private string _remark;

        /// <summary>
        /// 收藏ID
        /// </summary>
        public int FavoriteID
        {
            set { _favoriteid = value; }
            get { return _favoriteid; }
        }

        /// <summary>
        /// 课程
        /// </summary>
        public int? CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 节次
        /// </summary>
        public int? ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 用户
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        #endregion Model
    }
}