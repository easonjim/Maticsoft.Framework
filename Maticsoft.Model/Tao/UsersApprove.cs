using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// UsersApprove:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UsersApprove
    {
        public UsersApprove()
        { }

        #region Model

        private int _id;
        private int _userid;
        private int? _approvetype;
        private string _imgurl;
        private DateTime? _createddate;
        private int? _status;
        private DateTime? _approvedtime;
        private int? _approveduserid;

        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 认证资料类型 关联表 Accounts_UsersAuthentic中的ID
        /// </summary>
        public int? ApproveType
        {
            set { _approvetype = value; }
            get { return _approvetype; }
        }

        /// <summary>
        /// 认证资料地址
        /// </summary>
        public string ImgURL
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }

        /// <summary>
        /// 审核状态 0：未审核1：审核通过2：认证失败
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ApprovedTime
        {
            set { _approvedtime = value; }
            get { return _approvedtime; }
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public int? ApprovedUserID
        {
            set { _approveduserid = value; }
            get { return _approveduserid; }
        }

        #endregion Model
    }
}