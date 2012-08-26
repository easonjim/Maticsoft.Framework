using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// CourseNotes
    /// </summary>
    public partial class CourseNotes
    {
        private readonly Maticsoft.DAL.Tao.CourseNotes dal = new Maticsoft.DAL.Tao.CourseNotes();

        public CourseNotes()
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
        public bool Exists(int NoteID)
        {
            return dal.Exists(NoteID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseNotes model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.CourseNotes model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NoteID)
        {
            return dal.Delete(NoteID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string NoteIDlist)
        {
            return dal.DeleteList(NoteIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseNotes GetModel(int NoteID)
        {
            return dal.GetModel(NoteID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.CourseNotes GetModelByCache(int NoteID)
        {
            string CacheKey = "CourseNotesModel-" + NoteID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(NoteID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.CourseNotes)objModel;
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
        public List<Maticsoft.Model.Tao.CourseNotes> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.CourseNotes> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.CourseNotes> modelList = new List<Maticsoft.Model.Tao.CourseNotes>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.CourseNotes model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.CourseNotes();
                    if (dt.Rows[n]["NoteID"] != null && dt.Rows[n]["NoteID"].ToString() != "")
                    {
                        model.NoteID = int.Parse(dt.Rows[n]["NoteID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["Updatetime"] != null && dt.Rows[n]["Updatetime"].ToString() != "")
                    {
                        model.Updatetime = DateTime.Parse(dt.Rows[n]["Updatetime"].ToString());
                    }
                    if (dt.Rows[n]["Contents"] != null && dt.Rows[n]["Contents"].ToString() != "")
                    {
                        model.Contents = dt.Rows[n]["Contents"].ToString();
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
        /// 用户笔记
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CourseID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public DataSet GetCourseNotesList(int UserID, int CourseID, int ModuleID)
        {
            return dal.GetList(" UserID=" + UserID + " and CourseID=" + CourseID + " and ModuleID=" + ModuleID);
        }

        #endregion NewMethod
    }
}