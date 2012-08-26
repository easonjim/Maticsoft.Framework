using System;

namespace Maticsoft.Model.Messages
{
    /// <summary>
    /// SendedMessages:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ϢID
        /// </summary>
        public long SendMessageId
        {
            set { _sendmessageid = value; }
            get { return _sendmessageid; }
        }

        /// <summary>
        /// ������ID
        /// </summary>
        public int AddresserId
        {
            set { _addresserid = value; }
            get { return _addresserid; }
        }

        /// <summary>
        /// �ռ���ID
        /// </summary>
        public int AddresseeId
        {
            set { _addresseeid = value; }
            get { return _addresseeid; }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string PublishContent
        {
            set { _publishcontent = value; }
            get { return _publishcontent; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }

        /// <summary>
        /// ����ϢID
        /// </summary>
        public long? ReceiveMessageId
        {
            set { _receivemessageid = value; }
            get { return _receivemessageid; }
        }

        #endregion Model
    }
}