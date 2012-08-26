using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// CourseNotes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CourseNotes
    {
        public CourseNotes()
        { }

        #region Model

        private int _noteid;
        private int? _userid;
        private int? _courseid;
        private int? _moduleid;
        private DateTime? _updatetime;
        private string _contents;

        /// <summary>
        ///
        /// </summary>
        public int NoteID
        {
            set { _noteid = value; }
            get { return _noteid; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 课程ID
        /// </summary>
        public int? CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 小节ID
        /// </summary>
        public int? ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updatetime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }

        /// <summary>
        /// 笔记内容
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }

        #endregion Model
    }
}