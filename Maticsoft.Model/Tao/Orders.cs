using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Orders:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Orders
    {
        public Orders()
        { }

        #region Model

        private int _orderid;
        private DateTime _orderdate = DateTime.Now;
        private int _buyerid;
        private string _username;
        private string _email;
        private string _remark;
        private decimal? _amount;
        private int _status;
        private int? _sellerid;
        private int _paymenttypeid;
        private string _gatewayorderid;
        private string _paymenttype;
        private string _currencycode;
        private string _currencyname;

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }

        /// <summary>
        /// 购买者
        /// </summary>
        public int BuyerID
        {
            set { _buyerid = value; }
            get { return _buyerid; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        /// 状态0未付款 1已支付
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 发布人
        /// </summary>
        public int? SellerID
        {
            set { _sellerid = value; }
            get { return _sellerid; }
        }

        /// <summary>
        /// 支付类型接口
        /// </summary>
        public int PaymentTypeId
        {
            set { _paymenttypeid = value; }
            get { return _paymenttypeid; }
        }

        /// <summary>
        /// 网关订单ID
        /// </summary>
        public string GatewayOrderId
        {
            set { _gatewayorderid = value; }
            get { return _gatewayorderid; }
        }

        /// <summary>
        /// 支付类型名称
        /// </summary>
        public string PaymentType
        {
            set { _paymenttype = value; }
            get { return _paymenttype; }
        }

        /// <summary>
        /// 货币码
        /// </summary>
        public string CurrencyCode
        {
            set { _currencycode = value; }
            get { return _currencycode; }
        }

        /// <summary>
        /// 货币名称
        /// </summary>
        public string CurrencyName
        {
            set { _currencyname = value; }
            get { return _currencyname; }
        }

        #endregion Model
    }
}