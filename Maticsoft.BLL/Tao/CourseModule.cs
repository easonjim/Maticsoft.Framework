using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// CourseModule
    /// </summary>
    public partial class CourseModule
    {
        private readonly Maticsoft.DAL.Tao.CourseModule dal = new Maticsoft.DAL.Tao.CourseModule();

        public CourseModule()
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
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.CourseModule model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        public bool Delete(int iCourseId, int iModuleId)
        {
            return dal.Delete(iCourseId, iModuleId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModel(int CourseID, int ModuleID)
        {
            return dal.GetModel(CourseID, ModuleID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModelByCache(int ID)
        {
            string CacheKey = "CourseModuleModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.CourseModule)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据ModuleID获得数据列表
        /// </summary>
        public DataSet GetList(int iModuleID)
        {
            string strWhere = "ModuleID = " + iModuleID;
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
        public List<Maticsoft.Model.Tao.CourseModule> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.CourseModule> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.CourseModule> modelList = new List<Maticsoft.Model.Tao.CourseModule>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.CourseModule model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.CourseModule();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleIndex"] != null && dt.Rows[n]["ModuleIndex"].ToString() != "")
                    {
                        model.ModuleIndex = int.Parse(dt.Rows[n]["ModuleIndex"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"] != null && dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["UpdateDate"] != null && dt.Rows[n]["UpdateDate"].ToString() != "")
                    {
                        model.UpdateDate = DateTime.Parse(dt.Rows[n]["UpdateDate"].ToString());
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

        #endregion Method

        #region NewMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        public Maticsoft.Model.Tao.CourseModule GetModelByCourseID(int CourseID)
        {
            return GetModel(" CourseID=" + CourseID);
        }

        public Maticsoft.Model.Tao.CourseModule GetModelByCourseIDBF(int CourseID)
        {
            return GetModel("  CourseID=" + CourseID);
        }

        /// <summary>
        /// 获取课程的第一章节id
        /// </summary>
        /// <returns></returns>
        public int GetFirstModuleID(int CourseID)
        {
            int mid = 0;
            Maticsoft.Model.Tao.CourseModule courseModuleModel = GetModelByCourseID(CourseID);
            if (null != courseModuleModel)
            {
                mid = courseModuleModel.ModuleID;
            }
            return mid;
        }

        /// <summary>
        /// 获取课程的第一章节id
        /// </summary>
        /// <returns></returns>
        public int GetFirstMID(int CourseID)
        {
            int mid = 0;
            Maticsoft.Model.Tao.CourseModule courseModuleModel = dal.GetFirstModel(CourseID);
            if (null != courseModuleModel)
            {
                mid = courseModuleModel.ModuleID;
            }
            return mid;
        }

        #endregion NewMethod
    }
}