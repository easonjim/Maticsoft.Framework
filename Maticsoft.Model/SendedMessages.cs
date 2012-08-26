using System;

namespace Maticsoft.Model.Messages
{
    /// <summary>
    /// SendedMessages:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SendedMessages
    {
        public SendedMessages()
        { }

        #region Model

        private long _sendmessageid;
        private int _addresserid;
        private int _addresseeid;
        private string _title;
        private string _publishcontent;
        private DateTime _publishdate;
        private long? _receivemessageid;

        /// <summary>
        /// 发信息ID
        /// </summary>
        public long SendMessageId
        {
            set { _sendmessageid = value; }
            get { return _sendmessageid; }
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
        /// 发布日期
        /// </summary>
        public DateTime PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }

        /// <summary>
        /// 收信息ID
        /// </summary>
        public long? ReceiveMessageId
        {
            set { _receivemessageid = value; }
            get { return _receivemessageid; }
        }

        #endregion Model
    }
}