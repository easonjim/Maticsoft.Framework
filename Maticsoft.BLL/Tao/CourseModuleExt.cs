using System.Data;
using Maticsoft.Model;

namespace Maticsoft.BLL.Tao
{
    public partial class CourseModule
    {
        /// <summary>
        /// 保存学习资料
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public int UploadAttachment(Model.Tao.Courses courseModel)
        {
            return dal.UploadAttachment(courseModel);
        }

        public bool ExistsCourseModule(int iCourseID, int iModule)
        {
            return dal.ExistsCourseModule(iCourseID, iModule);
        }

        public int GetMaxModuleIndex(int CourseId)
        {
            return dal.GetMaxModuleIndex(CourseId);
        }

        public bool UpdateModuleIndex(Model.Tao.CourseModule model)
        {
            return dal.UpdateModuleIndex(model);
        }

        public DataTable GetCourseList(QueryCourses query)
        {
            return dal.GetCourseList(query);
        }

        public int GetCourseMouleCount(QueryCourses query)
        {
            return dal.GetCourseMouleCount(query);
        }

        public DataTable GetModuleList(QueryCourses query)
        {
            return dal.GetModuleList(query);
        }

        public DataSet GetCourseMoulePriceAndCount(QueryCourses query)
        {
            return dal.GetCourseMoulePriceAndCount(query);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist, int? iCourseID, int? ModuleID)
        {
            return dal.DeleteList(IDlist, iCourseID, ModuleID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Tao.CourseModule GetModel(int? ID, int? iCourseID, int? ModuleID)
        {
            return dal.GetModel(ID, iCourseID, ModuleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseModule model)
        {
            return dal.Add(model);
        }

        public bool SendEmailSuccess(int moduleId, int status)
        {
            return dal.SendEmailSuccess(moduleId, status);
        }

        public DataSet GetSearchRes(int startIndex, int pageSize, string keyStr, int orderType, string whereStr)
        {
            return dal.GetSearchRes(startIndex, pageSize, keyStr, orderType, whereStr);
        }

        public DataSet GetSearchByCateID(int startIndex, int pageSize, int orderType, int cateId)
        {
            return dal.GetSearchByCateID(startIndex, pageSize, orderType, cateId);
        }

        public int CourseRowsCount(string strKey, string strWhere)
        {
            return dal.CourseRowsCount(strKey, strWhere);
        }

        public int GetCountByCateId(int cateId)
        {
            return dal.GetCountByCateId(cateId);
        }

        public int GetCourserteacher(int courseId)
        {
            return dal.GetCourserteacher(courseId);
        }

        public int CourseCountByUid(int uid)
        {
            return dal.CourseCountByUid(uid);
        }

        public DataSet CourseBuUid(int startIndex, int pageSize, int? uid, int orderType)
        {
            return dal.CourseBuUid(startIndex, pageSize, uid, orderType);
        }
    }
}