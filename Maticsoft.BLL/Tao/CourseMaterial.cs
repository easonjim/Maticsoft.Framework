using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// CourseMaterial
    /// </summary>
    public partial class CourseMaterial
    {
        private readonly Maticsoft.DAL.Tao.CourseMaterial dal = new Maticsoft.DAL.Tao.CourseMaterial();

        public CourseMaterial()
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
        public bool Exists(int MaterialID)
        {
            return dal.Exists(MaterialID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseMaterial model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.CourseMaterial model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MaterialID)
        {
            return dal.Delete(MaterialID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string MaterialIDlist)
        {
            return dal.DeleteList(MaterialIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseMaterial GetModel(int MaterialID)
        {
            return dal.GetModel(MaterialID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.CourseMaterial GetModelByCache(int MaterialID)
        {
            string CacheKey = "CourseMaterialModel-" + MaterialID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(MaterialID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.CourseMaterial)objModel;
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
        public List<Maticsoft.Model.Tao.CourseMaterial> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.CourseMaterial> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.CourseMaterial> modelList = new List<Maticsoft.Model.Tao.CourseMaterial>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.CourseMaterial model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.CourseMaterial();
                    if (dt.Rows[n]["MaterialID"] != null && dt.Rows[n]["MaterialID"].ToString() != "")
                    {
                        model.MaterialID = int.Parse(dt.Rows[n]["MaterialID"].ToString());
                    }
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["MaterialURL"] != null && dt.Rows[n]["MaterialURL"].ToString() != "")
                    {
                        model.MaterialURL = dt.Rows[n]["MaterialURL"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
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
        /// 获取学习资料
        /// </summary>
        /// <param name="CourseID"></param>
        /// <param name="ModuleID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataSet GetCourseMaterialList(int CourseID, int Status)
        {
            return dal.GetList("CourseID=" + CourseID + " and Status=" + Status);
        }

        #endregion NewMethod
    }
}