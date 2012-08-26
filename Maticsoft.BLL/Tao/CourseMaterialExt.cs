using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class CourseMaterial
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCourseId(int courseId)
        {
            return dal.GetList(" CourseID=" + courseId);
        }
    }
}