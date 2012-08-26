using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// OrderItemHistory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderItemHistory
    {
        public OrderItemHistory()
        { }

        #region Model

        private int _itemid;
        private int _orderid;
        private int? _courseid;
        private int? _moduleid;
        private decimal? _price;
        private string _itemdescription;
        private string _imageurl;
        private string _remark;

        /// <summary>
        ///
        /// </summary>
        public int ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
        }

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
        public int? CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ItemDescription
        {
            set { _itemdescription = value; }
            get { return _itemdescription; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        #endregion Model
    }
}