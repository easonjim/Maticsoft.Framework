using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class Favorite
    {
        /// <summary>
        /// 获得CateID获得记录数
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int GetRecordCount(int UserId)
        {
            return dal.GetRecordCount(UserId);
        }

        /// <summary>
        /// 得到分页数据源
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSinglePageRecord(int? UserId, int startIndex, int endIndex)
        {
            return dal.GetSinglePageRecord(UserId, startIndex, endIndex);
        }

        public int CourseFavCount(int CourseId)
        {
            return dal.CourseFavCount(CourseId);
        }

        public int GetFavCourseCount(int courseId)
        {
            return dal.GetFavCourseCount(courseId);
        }
    }
}