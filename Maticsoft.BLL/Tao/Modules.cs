using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// Modules
    /// </summary>
    public partial class Modules
    {
        private readonly Maticsoft.DAL.Tao.Modules dal = new Maticsoft.DAL.Tao.Modules();

        public Modules()
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
        public bool Exists(int ModuleID)
        {
            return dal.Exists(ModuleID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strModuleName)
        {
            return dal.Exists(strModuleName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Modules model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Modules model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ModuleID)
        {
            return dal.Delete(ModuleID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ModuleIDlist)
        {
            return dal.DeleteList(ModuleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Modules GetModel(int ModuleID)
        {
            return dal.GetModel(ModuleID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.Modules GetModelByCache(int ModuleID)
        {
            string CacheKey = "ModulesModel-" + ModuleID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ModuleID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.Modules)objModel;
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
        public List<Maticsoft.Model.Tao.Modules> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Maticsoft.Model.Tao.Modules> GetModelByName(string strName)
        {
            DataSet ds = dal.GetList("ModuleName = " + strName);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Modules> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Modules> modelList = new List<Maticsoft.Model.Tao.Modules>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Modules model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Modules();
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleName"] != null && dt.Rows[n]["ModuleName"].ToString() != "")
                    {
                        model.ModuleName = dt.Rows[n]["ModuleName"].ToString();
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    if (dt.Rows[n]["TimeDuration"] != null && dt.Rows[n]["TimeDuration"].ToString() != "")
                    {
                        model.TimeDuration = int.Parse(dt.Rows[n]["TimeDuration"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.ImageUrl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["Type"] != null && dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["VideoContent"] != null && dt.Rows[n]["VideoContent"].ToString() != "")
                    {
                        model.VideoContent = dt.Rows[n]["VideoContent"].ToString();
                    }
                    if (dt.Rows[n]["CreatedDate"] != null && dt.Rows[n]["CreatedDate"].ToString() != "")
                    {
                        model.CreatedDate = DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.CreatedUserID = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.PV = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["Sequence"] != null && dt.Rows[n]["Sequence"].ToString() != "")
                    {
                        model.Sequence = int.Parse(dt.Rows[n]["Sequence"].ToString());
                    }
                    if (dt.Rows[n]["Attachment"] != null && dt.Rows[n]["Attachment"].ToString() != "")
                    {
                        model.Attachment = dt.Rows[n]["Attachment"].ToString();
                    }
                    if (dt.Rows[n]["UpdatedDate"] != null && dt.Rows[n]["UpdatedDate"].ToString() != "")
                    {
                        model.UpdatedDate = DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
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

        /// <summary>
        /// 更新浏览量
        /// </summary>
        public bool UpdatePV(int ModuleID)
        {
            return dal.UpdatePV(ModuleID);
        }

        public DataSet GetList(int courseID, int status)
        {
            return dal.GetList(courseID, status);
        }

        public int GetCounts(int courseID, int status)
        {
            return dal.GetCounts(courseID, status);
        }

        /// <summary>
        /// 批量处理数据
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            return dal.UpdateList(IDlist, strWhere);
        }

        #endregion NewMethod
    }
}