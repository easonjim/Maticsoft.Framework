using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// CourseModule:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CourseModule
    {
        public CourseModule()
        { }

        #region Model

        private int _id;
        private int _courseid;
        private int _moduleid;
        private int? _moduleindex;
        private DateTime? _createdate = DateTime.Now;
        private int? _status;
        private DateTime? _updatedate;

        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 章节ID
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 章节顺序
        /// </summary>
        public int? ModuleIndex
        {
            set { _moduleindex = value; }
            get { return _moduleindex; }
        }

        /// <summary>
        /// 创建时间 默认当前时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        /// <summary>
        /// 状态 0 :未发送邀请 1:已发送邀请 2:接收邀请 3:拒绝邀请
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }

        #endregion Model
    }
}