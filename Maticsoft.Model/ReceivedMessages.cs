using System;

namespace Maticsoft.Model.Messages
{
    /// <summary>
    /// ReceivedMessages:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �ռ���ID
        /// </summary>
        public long ReceiveMessageId
        {
            set { _receivemessageid = value; }
            get { return _receivemessageid; }
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
        /// ����ʱ��
        /// </summary>
        public DateTime PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }

        /// <summary>
        /// �Ƿ��Ѷ�
        /// </summary>
        public bool IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }

        #endregion Model
    }
}