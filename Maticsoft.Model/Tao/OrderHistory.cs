using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// OrderHistory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderHistory
    {
        public OrderHistory()
        { }

        #region Model

        private int _orderid;
        private DateTime _orderdate;
        private int _buyerid;
        private string _username;
        private string _email;
        private string _remark;
        private decimal? _amount;
        private int _status;
        private int _sellerid;
        private int _paymenttypeid;
        private string _gatewayorderid;
        private string _paymenttype;
        private string _currencycode;
        private string _currencyname;

        /// <summary>
        ///
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public int BuyerID
        {
            set { _buyerid = value; }
            get { return _buyerid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        ///
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        ///
        /// </summary>
        public int SellerID
        {
            set { _sellerid = value; }
            get { return _sellerid; }
        }

        /// <summary>
        ///
        /// </summary>
        public int PaymentTypeId
        {
            set { _paymenttypeid = value; }
            get { return _paymenttypeid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string GatewayOrderId
        {
            set { _gatewayorderid = value; }
            get { return _gatewayorderid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string PaymentType
        {
            set { _paymenttype = value; }
            get { return _paymenttype; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CurrencyCode
        {
            set { _currencycode = value; }
            get { return _currencycode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CurrencyName
        {
            set { _currencyname = value; }
            get { return _currencyname; }
        }

        #endregion Model
    }
}