using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// ApproveType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ApproveType
    {
        public ApproveType()
        { }

        #region Model

        private int _id;
        private string _approvename;

        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 认证类型
        /// </summary>
        public string ApproveName
        {
            set { _approvename = value; }
            get { return _approvename; }
        }

        #endregion Model
    }
}