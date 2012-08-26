using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// Comment
    /// </summary>
    public partial class Comment
    {
        private readonly Maticsoft.DAL.Tao.Comment dal = new Maticsoft.DAL.Tao.Comment();

        public Comment()
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
        public bool Exists(int CommentID)
        {
            return dal.Exists(CommentID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Comment model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Comment model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CommentID)
        {
            return dal.Delete(CommentID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CommentIDlist)
        {
            return dal.DeleteList(CommentIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Comment GetModel(int CommentID)
        {
            return dal.GetModel(CommentID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.Comment GetModelByCache(int CommentID)
        {
            string CacheKey = "CommentModel-" + CommentID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CommentID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.Comment)objModel;
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
        public List<Maticsoft.Model.Tao.Comment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return CommentDataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Comment> GetModelList(int commentId)
        {
            DataSet ds = dal.GetList(" CommentID=" + commentId);
            return CommentDataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Comment> CommentDataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Comment> modelList = new List<Maticsoft.Model.Tao.Comment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Comment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Comment();
                    if (dt.Rows[n]["CommentID"] != null && dt.Rows[n]["CommentID"].ToString() != "")
                    {
                        model.CommentID = int.Parse(dt.Rows[n]["CommentID"].ToString());
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
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Comment"] != null && dt.Rows[n]["Comment"].ToString() != "")
                    {
                        model.Comments = dt.Rows[n]["Comment"].ToString();
                    }
                    if (dt.Rows[n]["CommentDate"] != null && dt.Rows[n]["CommentDate"].ToString() != "")
                    {
                        model.CommentDate = DateTime.Parse(dt.Rows[n]["CommentDate"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["Score"] != null && dt.Rows[n]["Score"].ToString() != "")
                    {
                        model.Score = int.Parse(dt.Rows[n]["Score"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Comment> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Comment> modelList = new List<Maticsoft.Model.Tao.Comment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Comment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Comment();
                    if (dt.Rows[n]["CommentID"] != null && dt.Rows[n]["CommentID"].ToString() != "")
                    {
                        model.CommentID = int.Parse(dt.Rows[n]["CommentID"].ToString());
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
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Comment"] != null && dt.Rows[n]["Comment"].ToString() != "")
                    {
                        model.Comments = dt.Rows[n]["Comment"].ToString();
                    }
                    if (dt.Rows[n]["CommentDate"] != null && dt.Rows[n]["CommentDate"].ToString() != "")
                    {
                        model.CommentDate = DateTime.Parse(dt.Rows[n]["CommentDate"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["Score"] != null && dt.Rows[n]["Score"].ToString() != "")
                    {
                        model.Score = int.Parse(dt.Rows[n]["Score"].ToString());
                    }
                    if (dt.Rows[n]["CCount"] != null && dt.Rows[n]["CCount"].ToString() != "")
                    {
                        model.CCount = int.Parse(dt.Rows[n]["CCount"].ToString());
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
        /// 批量处理数据
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            return dal.UpdateList(IDlist, strWhere);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByCourseID(int CourseID)
        {
            return dal.GetList("Status=1 and CourseID=" + CourseID);
        }

        #endregion NewMethod
    }
}