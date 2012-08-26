using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// OrderItems:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderItems
    {
        public OrderItems()
        { }

        #region Model

        private int _itemid;
        private int? _orderid;
        private int? _courseid;
        private int? _moduleid;
        private decimal? _price;
        private string _itemdescription;
        private string _imageurl;
        private string _remark;

        /// <summary>
        /// 编号
        /// </summary>
        public int ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
        }

        /// <summary>
        /// 订单
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        /// 课程
        /// </summary>
        public int? CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 章节
        /// </summary>
        public int? ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string ItemDescription
        {
            set { _itemdescription = value; }
            get { return _itemdescription; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
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