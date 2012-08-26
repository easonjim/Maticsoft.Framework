using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Tao_SendInvite:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SendInvite
    {
        public SendInvite()
        { }

        #region Model

        private int _inviteid;
        private int _constitutorid;
        private int _inviteeid;
        private int _moduleid;
        private int _invitestatus;
        private DateTime _invitedate;
        private DateTime? _disposedate;

        /// <summary>
        ///
        /// </summary>
        public int InviteID
        {
            set { _inviteid = value; }
            get { return _inviteid; }
        }

        /// <summary>
        /// 组织者
        /// </summary>
        public int ConstitutorID
        {
            set { _constitutorid = value; }
            get { return _constitutorid; }
        }

        /// <summary>
        /// 被邀请人
        /// </summary>
        public int InviteeID
        {
            set { _inviteeid = value; }
            get { return _inviteeid; }
        }

        /// <summary>
        /// 课程小节ID
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 邀请状态：0，未处理；1，已接受；2，已拒绝
        /// </summary>
        public int InviteStatus
        {
            set { _invitestatus = value; }
            get { return _invitestatus; }
        }

        /// <summary>
        /// 邀请时间
        /// </summary>
        public DateTime InviteDate
        {
            set { _invitedate = value; }
            get { return _invitedate; }
        }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? DisposeDate
        {
            set { _disposedate = value; }
            get { return _disposedate; }
        }

        #endregion Model
    }
}