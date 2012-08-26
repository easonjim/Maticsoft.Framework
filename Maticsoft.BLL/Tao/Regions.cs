using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// Regions
    /// </summary>
    public partial class Regions
    {
        private readonly Maticsoft.DAL.Tao.Regions dal = new Maticsoft.DAL.Tao.Regions();

        public Regions()
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
        public bool Exists(int RegionId)
        {
            return dal.Exists(RegionId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Regions model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Regions model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RegionId)
        {
            return dal.Delete(RegionId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RegionIdlist)
        {
            return dal.DeleteList(RegionIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Regions GetModel(int RegionId)
        {
            return dal.GetModel(RegionId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.Regions GetModelByCache(int RegionId)
        {
            string CacheKey = "RegionsModel-" + RegionId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RegionId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.Regions)objModel;
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
        public List<Maticsoft.Model.Tao.Regions> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Regions> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Regions> modelList = new List<Maticsoft.Model.Tao.Regions>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Regions model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Regions();
                    if (dt.Rows[n]["AreaId"] != null && dt.Rows[n]["AreaId"].ToString() != "")
                    {
                        model.AreaId = int.Parse(dt.Rows[n]["AreaId"].ToString());
                    }
                    if (dt.Rows[n]["RegionId"] != null && dt.Rows[n]["RegionId"].ToString() != "")
                    {
                        model.RegionId = int.Parse(dt.Rows[n]["RegionId"].ToString());
                    }
                    if (dt.Rows[n]["ParentId"] != null && dt.Rows[n]["ParentId"].ToString() != "")
                    {
                        model.ParentId = int.Parse(dt.Rows[n]["ParentId"].ToString());
                    }
                    if (dt.Rows[n]["RegionName"] != null && dt.Rows[n]["RegionName"].ToString() != "")
                    {
                        model.RegionName = dt.Rows[n]["RegionName"].ToString();
                    }
                    if (dt.Rows[n]["DisplaySequence"] != null && dt.Rows[n]["DisplaySequence"].ToString() != "")
                    {
                        model.DisplaySequence = int.Parse(dt.Rows[n]["DisplaySequence"].ToString());
                    }
                    if (dt.Rows[n]["Path"] != null && dt.Rows[n]["Path"].ToString() != "")
                    {
                        model.Path = dt.Rows[n]["Path"].ToString();
                    }
                    if (dt.Rows[n]["Depth"] != null && dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
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