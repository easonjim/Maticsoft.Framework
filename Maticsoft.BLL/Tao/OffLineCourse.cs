/*----------------------------------------------------------------

// Copyright (C) 2012 动软卓越 版权所有。
//
// 文件名：OffLineCourse.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/07/20 11:27:22
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// OffLineCourse
    /// </summary>
    public partial class OffLineCourse
    {
        private readonly Maticsoft.DAL.Tao.OffLineCourse dal = new Maticsoft.DAL.Tao.OffLineCourse();

        public OffLineCourse()
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
        public bool Exists(int CourseID)
        {
            return dal.Exists(CourseID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.OffLineCourse model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.OffLineCourse model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CourseID)
        {
            return dal.Delete(CourseID);
        }

        /// <summary>
        /// 批量更新状态
        /// </summary>
        public bool UpdateList(string CourseIDlist, int Status)
        {
            return dal.UpdateList(CourseIDlist, Status);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CourseIDlist)
        {
            return dal.DeleteList(CourseIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.OffLineCourse GetModel(int CourseID)
        {
            return dal.GetModel(CourseID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.OffLineCourse GetModelByCache(int CourseID)
        {
            string CacheKey = "OffLineCourseModel-" + CourseID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CourseID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.OffLineCourse)objModel;
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
        public List<Maticsoft.Model.Tao.OffLineCourse> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.OffLineCourse> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.OffLineCourse> modelList = new List<Maticsoft.Model.Tao.OffLineCourse>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.OffLineCourse model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.OffLineCourse();
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["CourseName"] != null && dt.Rows[n]["CourseName"].ToString() != "")
                    {
                        model.CourseName = dt.Rows[n]["CourseName"].ToString();
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    if (dt.Rows[n]["CategoryId"] != null && dt.Rows[n]["CategoryId"].ToString() != "")
                    {
                        model.CategoryId = int.Parse(dt.Rows[n]["CategoryId"].ToString());
                    }
                    if (dt.Rows[n]["StartTime"] != null && dt.Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
                    }
                    if (dt.Rows[n]["EndTime"] != null && dt.Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
                    }
                    if (dt.Rows[n]["TimeSpan"] != null && dt.Rows[n]["TimeSpan"].ToString() != "")
                    {
                        model.TimeSpan = dt.Rows[n]["TimeSpan"].ToString();
                    }
                    if (dt.Rows[n]["RegionID"] != null && dt.Rows[n]["RegionID"].ToString() != "")
                    {
                        model.RegionID = int.Parse(dt.Rows[n]["RegionID"].ToString());
                    }
                    if (dt.Rows[n]["CoursePrice"] != null && dt.Rows[n]["CoursePrice"].ToString() != "")
                    {
                        model.CoursePrice = decimal.Parse(dt.Rows[n]["CoursePrice"].ToString());
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    if (dt.Rows[n]["ImageURL"] != null && dt.Rows[n]["ImageURL"].ToString() != "")
                    {
                        model.ImageURL = dt.Rows[n]["ImageURL"].ToString();
                    }
                    if (dt.Rows[n]["LimitCount"] != null && dt.Rows[n]["LimitCount"].ToString() != "")
                    {
                        model.LimitCount = int.Parse(dt.Rows[n]["LimitCount"].ToString());
                    }
                    if (dt.Rows[n]["Recommended"] != null && dt.Rows[n]["Recommended"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Recommended"].ToString() == "1") || (dt.Rows[n]["Recommended"].ToString().ToLower() == "true"))
                        {
                            model.Recommended = true;
                        }
                        else
                        {
                            model.Recommended = false;
                        }
                    }
                    if (dt.Rows[n]["Latest"] != null && dt.Rows[n]["Latest"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Latest"].ToString() == "1") || (dt.Rows[n]["Latest"].ToString().ToLower() == "true"))
                        {
                            model.Latest = true;
                        }
                        else
                        {
                            model.Latest = false;
                        }
                    }
                    if (dt.Rows[n]["Hotsale"] != null && dt.Rows[n]["Hotsale"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Hotsale"].ToString() == "1") || (dt.Rows[n]["Hotsale"].ToString().ToLower() == "true"))
                        {
                            model.Hotsale = true;
                        }
                        else
                        {
                            model.Hotsale = false;
                        }
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.PV = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["AttentionCount"] != null && dt.Rows[n]["AttentionCount"].ToString() != "")
                    {
                        model.AttentionCount = int.Parse(dt.Rows[n]["AttentionCount"].ToString());
                    }
                    if (dt.Rows[n]["BookCount"] != null && dt.Rows[n]["BookCount"].ToString() != "")
                    {
                        model.BookCount = int.Parse(dt.Rows[n]["BookCount"].ToString());
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.CreatedUserID = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["CreatedDate"] != null && dt.Rows[n]["CreatedDate"].ToString() != "")
                    {
                        model.CreatedDate = DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedDate"] != null && dt.Rows[n]["UpdatedDate"].ToString() != "")
                    {
                        model.UpdatedDate = DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion Method

        public bool UpdateOffLineCourseStatus(int status, int courseId)
        {
            return dal.UpdateOffLineCourseStatus(status, courseId);
        }

        public DataSet unPublishCourseInfo(int userID, int startIndex, int pageSize, int status)
        {
            return dal.unPublishCourseInfo(userID, startIndex, pageSize, status);
        }

        public int unPublishCount(int userId, int status)
        {
            return dal.unPublishCount(userId, status);
        }

        public bool DeleteCourseunApprove(int courseId)
        {
            return dal.DeleteCourseunApprove(courseId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.OffLineCourse> GetModelList()
        {
            DataSet ds = dal.GetList();
            return DataTableToList(ds.Tables[0]);
        }

        public DataSet GetOff()
        {
            return dal.GetOff();
        }

        public DataSet GetIndexList(int pi, int ps, int uid, int type)
        {
            return dal.GetIndexList(pi, ps, uid, type);
        }

        public int IndexListCount(int uid, int type)
        {
            return dal.IndexListCount(uid, type);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, int OrderType, string TimeStr)
        {
            return dal.GetListByCateId(out rowCount, out pageCount, CateId, PageIndex, PageSize, OrderType, TimeStr);
        }
    }
}