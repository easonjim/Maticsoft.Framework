using System;

namespace Maticsoft.Model
{
    [Serializable]
    public class AccountTrade
    {
        public AccountTrade()
        { }

        private decimal _pay;

        /// <summary>
        /// 总支出
        /// </summary>
        public decimal Pay
        {
            get { return _pay; }
            set { _pay = value; }
        }

        private int? _buycourse;

        /// <summary>
        /// 购买课程数量
        /// </summary>
        public int? Buycourse
        {
            get { return _buycourse; }
            set { _buycourse = value; }
        }

        private decimal _income;

        /// <summary>
        /// 总收入
        /// </summary>
        public decimal Income
        {
            get { return _income; }
            set { _income = value; }
        }

        private int? _sellCount;

        /// <summary>
        /// 出售课程数量
        /// </summary>
        public int? SellCount
        {
            get { return _sellCount; }
            set { _sellCount = value; }
        }

        private decimal _recharge;

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Recharge
        {
            get { return _recharge; }
            set { _recharge = value; }
        }

        private int? _count;

        /// <summary>
        /// 充值次数
        /// </summary>
        public int? Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private decimal _blance;

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Blance
        {
            get { return _blance; }
            set { _blance = value; }
        }

        private int _userID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private DateTime? _creatTime;

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? CreatTime
        {
            get { return _creatTime; }
            set { _creatTime = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}