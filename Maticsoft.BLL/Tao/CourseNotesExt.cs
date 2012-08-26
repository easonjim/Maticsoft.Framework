using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class CourseNotes
    {
        /// <summary>
        /// 获取课程笔记信息
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public DataSet GetCourseNote(int? uid, int startindex, int pagesize)
        {
            return dal.GetCourseNote(uid, startindex, pagesize);
        }

        public int SumNoteCourse(int userId)
        {
            return dal.SumNoteCourse(userId);
        }

        public static DataSet GetCourseNotes(int uid, int mid)
        {
            return DAL.Tao.CourseNotes.GetCourseNotes(uid, mid);
        }
    }
}