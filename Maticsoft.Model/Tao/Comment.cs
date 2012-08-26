using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Comment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Comment
    {
        public Comment()
        { }

        #region Model

        private int _commentid;
        private int? _orderid;
        private int _courseid;
        private int _moduleid;
        private int _userid;
        private string _comment;
        private DateTime _commentdate;
        private int? _parentid = 0;
        private int? _score = 0;
        private Int16 _status = 0;

        private int? _cCount;

        public int? CCount
        {
            get { return _cCount; }
            set { _cCount = value; }
        }

        /// <summary>
        /// 评论编号
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        /// 课程
        /// </summary>
        public int CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 节次
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 评论人
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Comments
        {
            set { _comment = value; }
            get { return _comment; }
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentDate
        {
            set { _commentdate = value; }
            get { return _commentdate; }
        }

        /// <summary>
        /// 对用户评论内容进行回复
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }

        /// <summary>
        /// 评论分值
        /// </summary>
        public int? Score
        {
            set { _score = value; }
            get { return _score; }
        }

        /// <summary>
        /// 状态  0：未审核，1：审核
        /// </summary>
        public Int16 Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion Model

        private int _type;

        /// <summary>
        /// 评论类型 0：网络课程 1 ：线下课程
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}