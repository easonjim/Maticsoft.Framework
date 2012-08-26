using System;

namespace Maticsoft.Model.Messages
{
    /// <summary>
    /// ReceivedMessages:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ReceivedMessages
    {
        public ReceivedMessages()
        { }

        #region Model

        private long _receivemessageid;
        private int _addresserid;
        private int _addresseeid;
        private string _title;
        private string _publishcontent;
        private DateTime _publishdate;
        private DateTime _lasttime;
        private bool _isread;

        /// <summary>
        /// 收件箱ID
        /// </summary>
        public long ReceiveMessageId
        {
            set { _receivemessageid = value; }
            get { return _receivemessageid; }
        }

        /// <summary>
        /// 发件人ID
        /// </summary>
        public int AddresserId
        {
            set { _addresserid = value; }
            get { return _addresserid; }
        }

        /// <summary>
        /// 收件人ID
        /// </summary>
        public int AddresseeId
        {
            set { _addresseeid = value; }
            get { return _addresseeid; }
        }

        /// <summary>
        /// 消息主题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string PublishContent
        {
            set { _publishcontent = value; }
            get { return _publishcontent; }
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }

        #endregion Model
    }
}