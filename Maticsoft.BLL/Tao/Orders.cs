using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// Orders
    /// </summary>
    public partial class Orders
    {
        private readonly Maticsoft.DAL.Tao.Orders dal = new Maticsoft.DAL.Tao.Orders();

        public Orders()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BuyerID, int OrderID)
        {
            return dal.Exists(BuyerID, OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Orders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Orders model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OrderID)
        {
            return dal.Delete(OrderID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BuyerID, int OrderID)
        {
            return dal.Delete(BuyerID, OrderID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            return dal.DeleteList(OrderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Orders GetModel(int OrderID)
        {
            return dal.GetModel(OrderID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.Orders GetModelByCache(int OrderID)
        {
            string CacheKey = "OrdersModel-" + OrderID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(OrderID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.Orders)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Orders> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Maticsoft.Model.Tao.Orders> GetTotalPrice(int? orderId)
        {
            DataSet ds = dal.GetList(" OrderID=" + orderId);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Orders> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Orders> modelList = new List<Maticsoft.Model.Tao.Orders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Orders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Orders();
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
                    }
                    if (dt.Rows[n]["BuyerID"] != null && dt.Rows[n]["BuyerID"].ToString() != "")
                    {
                        model.BuyerID = int.Parse(dt.Rows[n]["BuyerID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SellerID"] != null && dt.Rows[n]["SellerID"].ToString() != "")
                    {
                        model.SellerID = int.Parse(dt.Rows[n]["SellerID"].ToString());
                    }
                    if (dt.Rows[n]["PaymentTypeId"] != null && dt.Rows[n]["PaymentTypeId"].ToString() != "")
                    {
                        model.PaymentTypeId = int.Parse(dt.Rows[n]["PaymentTypeId"].ToString());
                    }
                    if (dt.Rows[n]["GatewayOrderId"] != null && dt.Rows[n]["GatewayOrderId"].ToString() != "")
                    {
                        model.GatewayOrderId = dt.Rows[n]["GatewayOrderId"].ToString();
                    }
                    if (dt.Rows[n]["PaymentType"] != null && dt.Rows[n]["PaymentType"].ToString() != "")
                    {
                        model.PaymentType = dt.Rows[n]["PaymentType"].ToString();
                    }
                    if (dt.Rows[n]["CurrencyCode"] != null && dt.Rows[n]["CurrencyCode"].ToString() != "")
                    {
                        model.CurrencyCode = dt.Rows[n]["CurrencyCode"].ToString();
                    }
                    if (dt.Rows[n]["CurrencyName"] != null && dt.Rows[n]["CurrencyName"].ToString() != "")
                    {
                        model.CurrencyName = dt.Rows[n]["CurrencyName"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion Method
    }
}