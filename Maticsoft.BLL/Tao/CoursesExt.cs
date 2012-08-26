using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maticsoft.BLL.Tao
{
    public partial class Courses
    {
        /// <summary>
        /// 添加新的课程信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCourse(Model.Tao.Courses model)
        {
            return dal.AddNewCourse(model);
        }

        /// <summary>
        /// 删除数据表中的URL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateAttachUrl(int id)
        {
            return dal.UpdateAttachUrl(id);
        }

        /// <summary>
        /// 根据CourseID得到CourseName
        /// </summary>
        public Model.Tao.Courses GetCourseName(int CourseID)
        {
            return dal.GetCourseName(CourseID);
        }

        /// <summary>
        /// 保存学习资料
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public int UploadAttachment(Model.Tao.Courses courseModel)
        {
            return dal.UploadAttachment(courseModel);
        }

        /// <summary>
        /// 更新课程的发布价格和课程时效
        /// </summary>
        public int UPdateCoursePrice(Model.Tao.Courses model)
        {
            return dal.UPdateCoursePrice(model);
        }

        /// <summary>
        /// 发布课程
        /// </summary>
        public int PublishCourse(int courseId)
        {
            return dal.PublishCourse(courseId);
        }

        public int PubCourse(int courseId, int status)
        {
            return dal.PubCourse(courseId, status);
        }

        /// <summary>
        /// 修改课程缩略图
        /// </summary>
        /// <param name="courseId">课程ID</param>
        /// <returns></returns>
        public bool EditCourseThumbnai(Model.Tao.Courses modle)
        {
            return dal.EditCourseThumbnai(modle);
        }

        /// <summary>
        /// 课程信息列表
        /// </summary>
        /// <param name="CateId">课程分类ID</param>
        /// <param name="Orderstr">排序条件</param>
        /// <returns></returns>
        public DataSet GetCourseList(int CateId, string Orderstr)
        {
            return dal.GetCourseList(CateId, Orderstr);
        }

        /// <summary>
        /// 获得CateID获得记录数
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public int GetRecordCount(int cateId)
        {
            return dal.GetRecordCount(cateId);
        }

        /// <summary>
        /// 获取分页数据信息
        /// </summary>
        /// <param name="WhereStr">查询条件</param>
        /// <param name="OrderStr">排序规则</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="RowCount">总行数</param>
        /// <param name="PageCount">总页数</param>
        /// <returns></returns>
        public DataSet GetPageRecord(string WhereStr, string OrderStr, int pageIndex, out int RowCount, out int PageCount)
        {
            return dal.GetPageRecord(WhereStr, OrderStr, pageIndex, out RowCount, out PageCount);
        }

        /// <summary>
        /// 得到分页数据源
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSinglePageRecord(int startIndex, int endIndex)
        {
            return dal.GetSinglePageRecord(startIndex, endIndex);
        }

        /// <summary>
        /// 获得近三个月已开课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int PublishCourseCount(int userID, int status, int ctypes)
        {
            return dal.PublishCourseCount(userID, status, ctypes);
        }

        /// <summary>
        /// 获得线下课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int PublishOfflineCourseCount(int userID, int status)
        {
            return dal.PublishOfflineCourseCount(userID, status);
        }

        /// <summary>
        /// 获得三个月前已开课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        //public int CourseCountHis(int userID)
        //{
        //    return dal.PublishCourseCount(userID, "");
        //}

        /// <summary>
        /// 得到已开课程信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="startIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="RowCount">总行数</param>
        /// <returns></returns>
        public DataSet GetPubLishCourse(int userID, int startIndex, int pageSize, int status, int ctypes)
        {
            return dal.GetPubLishCourse(userID, startIndex, pageSize, status, ctypes);
        }

        /// <summary>
        /// 得到已开课程信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="startIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="RowCount">总行数</param>
        /// <returns></returns>
        public DataSet GetPubLishOffLineCourse(int userID, int startIndex, int pageSize, int Status)
        {
            return dal.GetPubLishOffLineCourse(userID, startIndex, pageSize, Status);
        }

        #region 获得未发布课程信息、未审核课程信息

        /// <summary>
        /// 获取所有未发布、未审核课程的数量
        /// </summary>
        public int unPubCourseCount(int userId, int status)
        {
            return dal.unPubCourseCount(userId, status);
        }

        /// <summary>
        /// 根据ID获取为完成的课程
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet UnPubCourse(int userID, int startIndex, int pageSize, int status)
        {
            return dal.UnPubCourse(userID, startIndex, pageSize, status);
        }

        #endregion 获得未发布课程信息、未审核课程信息

        /// <summary>
        /// 根据课程的状态、类别得到不同的结果集
        /// </summary>
        public DataSet PublishCourseInfo(Model.Tao.Courses model)
        {
            return dal.PublishCourseInfo(model);
        }

        public DataSet GetOrgCourse(int userId)
        {
            return dal.GetOrgCourse(userId);
        }

        public bool updateOrgCourse(Model.Tao.Courses model)
        {
            return dal.updateOrgCourse(model);
        }

        public int changeCourseType(int courseId)
        {
            return dal.changeCourseType(courseId);
        }

        public int getModelCount(int courseId)
        {
            return dal.getModelCount(courseId);
        }

        public int unPublishCount(int userId, int status)
        {
            return dal.unPublishCount(userId, status);
        }

        public int unOffLinePublishCount(int userId, int status)
        {
            return dal.unOffLinePublishCount(userId, status);
        }

        public DataSet unPublishCourseInfo(int userID, int startIndex, int pageSize, int status)
        {
            return dal.unPublishCourseInfo(userID, startIndex, pageSize, status);
        }

        public DataSet unPublishOfflineCourseInfo(int userID, int startIndex, int pageSize, int status)
        {
            return dal.unPublishOfflineCourseInfo(userID, startIndex, pageSize, status);
        }

        public int DeleteCourseunApprove(int courseId)
        {
            return dal.DeleteCourseunApprove(courseId);
        }

        public bool UpdateModuleCount(int courseId, int ModuleCount)
        {
            return dal.UpdateModuleCount(courseId, ModuleCount);
        }

        public bool UpdateModuleCount(int courseId, int ModuleCount, int Time)
        {
            return dal.UpdateModuleCount(courseId, ModuleCount, Time);
        }

        public int orgCourseCount(int userId)
        {
            return dal.orgCourseCount(userId);
        }

        public DataSet getOrgCourseInfo(int startindex, int pagesize, int userId)
        {
            return dal.getOrgCourseInfo(startindex, pagesize, userId);
        }

        public string GetUserNameByCourseId(int courseId)
        {
            DataSet ds = dal.GetUserNameByCourseId(courseId);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Text.StringBuilder strName = new StringBuilder();
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strName.Append(dt.Rows[i]["TrueName"] + ",");
                    }
                    return strName.ToString();
                }
                else
                {
                    return "不详";
                }
            }
            else
            {
                return "不详";
            }
        }

        public bool UpdataCourseTime(int cid, int time)
        {
            return dal.UpdataCourseTime(cid, time);
        }

        public bool UpdataCourseStatus(int cid)
        {
            return dal.UpdataCourseStatus(cid);
        }

        /// <summary>
        /// 首页推荐课程
        /// </summary>
        public DataSet GetRecommendedCourse(int? topSum)
        {
            return dal.GetRecommendedCourse(topSum);
        }

        public DataSet GetIndexList(int pi, int ps, int cateId)
        {
            return dal.GetIndexList(pi, ps, cateId);
        }

        public int IndexListCount(int cateId)
        {
            return dal.IndexListCount(cateId);
        }

        public DataSet GetHotCourse(string andStr)
        {
            return dal.GetHotCourse(andStr);
        }

        public DataSet GetLastCourse(int pi)
        {
            return dal.GetLastCourse(pi);
        }

        public static int GetUploadType(int cid)
        {
            return DAL.Tao.Courses.GetUploadType(cid);
        }

        public List<Maticsoft.Model.Tao.SearchCourse> GetRecommendedCourseList(int? topSum)
        {
            return dal.GetRecommendedCourseList(topSum);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, bool topNum)
        {
            return dal.GetListCateId(out rowCount, out pageCount, CateId, PageIndex, PageSize, topNum);
        }

        public List<Maticsoft.Model.Tao.Courses> GetHotKey()
        {
            DataSet ds = GetHotList(6);
            if (ds == null)
            {
                return null;
            }
            else
            {
                return DataTableToList(ds.Tables[0]);
            }
        }

        /// <summary>
        /// 获得相关课程信息
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize)
        {
            return dal.GetListByCateId(out rowCount, out pageCount, CateId, PageIndex, PageSize);
        }

        /// <summary>
        /// 根据教师获得相关课程信息
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByTeacherID(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize)
        {
            return dal.GetListByTeacherID(out rowCount, out pageCount, CateId, PageIndex, PageSize);
        }

        public int GetPubSourse(int uid)
        {
            return dal.GetPubSourse(uid);
        }

        public int GetSellCourseNum(int couresid)
        {
            return dal.GetSellCourseNum(couresid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType)
        {
            return dal.GetListByCateId(out rowCount, out pageCount, CateId, PageIndex, PageSize, OrderType, TimeStr, CourseType);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByuserID(out int rowCount, out int pageCount, int Uid, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType)
        {
            return dal.GetListByuserID(out rowCount, out pageCount, Uid, PageIndex, PageSize, OrderType, TimeStr, CourseType);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByKEY(out int rowCount, out int pageCount, string keyStr, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType, int? dpt)
        {
            return dal.GetListByKEY(out rowCount, out pageCount, keyStr, PageIndex, PageSize, OrderType, TimeStr, CourseType, dpt);
        }

        public int GetTeacherCount(int courseId)
        {
            return dal.GetTeacherCount(courseId);
        }

        public int PublishCourseCount(int userID)
        {
            return dal.PublishCourseCount(userID);
        }
    }
}