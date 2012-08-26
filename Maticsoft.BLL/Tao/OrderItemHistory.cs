using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// OrderItemHistory
    /// </summary>
    public partial class OrderItemHistory
    {
        private readonly Maticsoft.DAL.Tao.OrderItemHistory dal = new Maticsoft.DAL.Tao.OrderItemHistory();

        public OrderItemHistory()
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
        public bool Exists(int ItemID, int OrderID)
        {
            return dal.Exists(ItemID, OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.Tao.OrderItemHistory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.OrderItemHistory model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ItemID, int OrderID)
        {
            return dal.Delete(ItemID, OrderID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.OrderItemHistory GetModel(int ItemID, int OrderID)
        {
            return dal.GetModel(ItemID, OrderID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.OrderItemHistory GetModelByCache(int ItemID, int OrderID)
        {
            string CacheKey = "OrderItemHistoryModel-" + ItemID + OrderID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ItemID, OrderID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.OrderItemHistory)objModel;
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
        public List<Maticsoft.Model.Tao.OrderItemHistory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.OrderItemHistory> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.OrderItemHistory> modelList = new List<Maticsoft.Model.Tao.OrderItemHistory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.OrderItemHistory model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.OrderItemHistory();
                    if (dt.Rows[n]["ItemID"] != null && dt.Rows[n]["ItemID"].ToString() != "")
                    {
                        model.ItemID = int.Parse(dt.Rows[n]["ItemID"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["ItemDescription"] != null && dt.Rows[n]["ItemDescription"].ToString() != "")
                    {
                        model.ItemDescription = dt.Rows[n]["ItemDescription"].ToString();
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.ImageUrl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
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

        #region NewMethod

        #region 根据UserID从Tao_OrderItemHistory查询所有的ModuleID

        /// <summary>
        /// 根据UserID从Tao_OrderItemHistory查询所有的ModuleID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<int> GetIDList(int UserID)
        {
            List<int> list = new List<int>();
            DataSet ds = dal.GetModuleIDList(UserID);
            if (null != ds && ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Columns.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (null != dr["ModuleID"])
                    {
                        if (PageValidate.IsNumber(dr["ModuleID"].ToString()))
                        {
                            list.Add(Convert.ToInt32(dr["ModuleID"]));
                        }
                    }
                }
            }
            return list;
        }

        #endregion 根据UserID从Tao_OrderItemHistory查询所有的ModuleID

        #endregion NewMethod
    }
}