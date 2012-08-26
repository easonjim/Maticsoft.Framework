using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// CourseMaterial:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CourseMaterial
    {
        public CourseMaterial()
        { }

        #region Model

        private int _materialid;
        private int _courseid;
        private int? _moduleid;
        private string _materialurl;
        private int _status;
        private string _materialname;

        public string Materialname
        {
            get { return _materialname; }
            set { _materialname = value; }
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
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
        /// 小节ID
        /// </summary>
        public int? ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 学习资料地址
        /// </summary>
        public string MaterialURL
        {
            set { _materialurl = value; }
            get { return _materialurl; }
        }

        /// <summary>
        /// 审核状态：0 ：未完成、未发布1：已发布、未审核2：审核通过3：审核失败
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        #endregion Model
    }
}