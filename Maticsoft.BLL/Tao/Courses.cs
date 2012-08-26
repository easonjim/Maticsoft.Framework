using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// Courses
    /// </summary>
    public partial class Courses
    {
        private readonly Maticsoft.DAL.Tao.Courses dal = new Maticsoft.DAL.Tao.Courses();

        public Courses()
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
        public int Add(Maticsoft.Model.Tao.Courses model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Courses model)
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CourseIDlist)
        {
            return dal.DeleteList(CourseIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Courses GetModel(int CourseID)
        {
            return dal.GetModel(CourseID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.Courses GetModelByCache(int CourseID)
        {
            string CacheKey = "CoursesModel-" + CourseID;
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
            return (Maticsoft.Model.Tao.Courses)objModel;
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
        /// 获取推荐课程
        /// </summary>
        public DataSet GetCourseTop(int iUserID, int Top)
        {
            string strWhere = "TC.CreatedUserID = " + iUserID;
            string filedOrder = "TC.CourseID";
            return dal.GetCourseTop(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取推荐课程
        /// </summary>
        public DataSet GetRecommendedCourseList(int iCourseID, int Top)
        {
            string strWhere = "TC.CourseID = " + iCourseID + "And TC.Recommended = 'true'";
            string filedOrder = "TCM.ModuleIndex";
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Courses> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Maticsoft.Model.Tao.Courses> PayGetCourseInfo(int? cid)
        {
            DataSet ds = dal.GetList("  CourseId=" + cid.Value);
            return DataTableToList(ds.Tables[0]);
        }

        public DataSet getShopCourseInfo(int? cid)
        {
            if (cid.HasValue)
            {
                DataSet ds = dal.GetList("  CourseId=" + cid.Value);
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Courses> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Courses> modelList = new List<Maticsoft.Model.Tao.Courses>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Courses model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Courses();
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
                    if (dt.Rows[n]["ShortDescription"] != null && dt.Rows[n]["ShortDescription"].ToString() != "")
                    {
                        model.ShortDescription = dt.Rows[n]["ShortDescription"].ToString();
                    }
                    if (dt.Rows[n]["CategoryId"] != null && dt.Rows[n]["CategoryId"].ToString() != "")
                    {
                        model.CategoryId = int.Parse(dt.Rows[n]["CategoryId"].ToString());
                    }
                    if (dt.Rows[n]["TimeDuration"] != null && dt.Rows[n]["TimeDuration"].ToString() != "")
                    {
                        model.TimeDuration = int.Parse(dt.Rows[n]["TimeDuration"].ToString());
                    }
                    if (dt.Rows[n]["CourseSpan"] != null && dt.Rows[n]["CourseSpan"].ToString() != "")
                    {
                        model.CourseSpan = int.Parse(dt.Rows[n]["CourseSpan"].ToString());
                    }
                    if (dt.Rows[n]["ExpiryDate"] != null && dt.Rows[n]["ExpiryDate"].ToString() != "")
                    {
                        model.ExpiryDate = DateTime.Parse(dt.Rows[n]["ExpiryDate"].ToString());
                    }
                    if (dt.Rows[n]["ViewCount"] != null && dt.Rows[n]["ViewCount"].ToString() != "")
                    {
                        model.ViewCount = int.Parse(dt.Rows[n]["ViewCount"].ToString());
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
                    if (dt.Rows[n]["SpecialOffer"] != null && dt.Rows[n]["SpecialOffer"].ToString() != "")
                    {
                        if ((dt.Rows[n]["SpecialOffer"].ToString() == "1") || (dt.Rows[n]["SpecialOffer"].ToString().ToLower() == "true"))
                        {
                            model.SpecialOffer = true;
                        }
                        else
                        {
                            model.SpecialOffer = false;
                        }
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.PV = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["SalesVolume"] != null && dt.Rows[n]["SalesVolume"].ToString() != "")
                    {
                        model.SalesVolume = int.Parse(dt.Rows[n]["SalesVolume"].ToString());
                    }
                    if (dt.Rows[n]["Sequence"] != null && dt.Rows[n]["Sequence"].ToString() != "")
                    {
                        model.Sequence = int.Parse(dt.Rows[n]["Sequence"].ToString());
                    }
                    if (dt.Rows[n]["Attachment"] != null && dt.Rows[n]["Attachment"].ToString() != "")
                    {
                        model.Attachment = dt.Rows[n]["Attachment"].ToString();
                    }
                    if (dt.Rows[n]["ModuleNum"] != null && dt.Rows[n]["ModuleNum"].ToString() != "")
                    {
                        model.ModuleNum = int.Parse(dt.Rows[n]["ModuleNum"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedDate"] != null && dt.Rows[n]["UpdatedDate"].ToString() != "")
                    {
                        model.UpdatedDate = DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
                    }
                    if (dt.Rows[n]["CourseTypes"] != null && dt.Rows[n]["CourseTypes"].ToString() != "")
                    {
                        model.CourseTypes = int.Parse(dt.Rows[n]["CourseTypes"].ToString());
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
        public bool UpdatePV(int CourseID)
        {
            return dal.UpdatePV(CourseID);
        }

        /// <summary>
        /// 批量更新状态
        /// </summary>
        public bool UpdateList(string CourseIDlist, int Status)
        {
            return dal.UpdateList(CourseIDlist, Status);
        }

        /// <summary>
        /// 批量课程推荐
        /// </summary>
        public bool UpdateRecommendedList(string CourseIDlist, int Status, string colum)
        {
            return dal.UpdateRecommendedList(CourseIDlist, Status, colum);
        }

        /// <summary>
        /// 获取所有老师
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public DataSet GetCreatedUserIDList(int CourseID)
        {
            return dal.GetCreatedUserIDList(CourseID);
        }

        /// <summary>
        /// 前5个相关课程推荐
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public DataSet GetCorrelatedCurriculum(int CourseID, int count)
        {
            return dal.GetCorrelatedCurriculum(CourseID, count);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetHotList(int Top)
        {
            return dal.GetHotList(Top, " Status=3", "PV desc");
        }

        #endregion NewMethod
    }
}