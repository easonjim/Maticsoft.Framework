using Maticsoft.Payment.Model;

namespace Maticsoft.Model.Tao
{
    public partial class Orders : IOrderBase
    {
        #region IOrderBase 成员

        public ActivityStatus ActivityStatus { get; set; }

        public RefundStatus RefundStatus { get; set; }

        public PaymentStatus PaymentStatus
        {
            get
            {
                return (PaymentStatus)this._status;
            }
            set
            {
                this._status = (int)value;
            }
        }

        public ShippingStatus ShippingStatus { get; set; }

        public string BuyerEmailAddress
        {
            get { return this.Email; }
            set { this.Email = value; }
        }

        #endregion IOrderBase 成员
    }
}