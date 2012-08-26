using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// TradeDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TradeDetails
    {
        public TradeDetails()
        { }

        #region Model

        private int _id;
        private int _userid;
        private DateTime _createdate;
        private int _tradetype;
        private decimal? _tradeamount;
        private decimal? _pay;

        public decimal? Pay
        {
            get { return _pay; }
            set { _pay = value; }
        }

        private decimal? _balance;
        private int _payer;
        private int _payee;
        private int _paymenttypeid;
        private int _status;
        private string _remark;

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        /// <summary>
        /// 交易类型: 0 收入(出售课程) 1:支出(购买课程) 2:充值 3:(提现)
        /// </summary>
        public int TradeType
        {
            set { _tradetype = value; }
            get { return _tradetype; }
        }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? TradeAmount
        {
            set { _tradeamount = value; }
            get { return _tradeamount; }
        }

        /// <summary>
        /// 余额--对应用户扩展表里的余额
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }

        /// <summary>
        /// 付款人
        /// </summary>
        public int Payer
        {
            set { _payer = value; }
            get { return _payer; }
        }

        /// <summary>
        ///
        /// </summary>
        public int Payee
        {
            set { _payee = value; }
            get { return _payee; }
        }

        /// <summary>
        /// 支付类型ID
        /// </summary>
        public int PaymentTypeId
        {
            set { _paymenttypeid = value; }
            get { return _paymenttypeid; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        #endregion Model
    }
}