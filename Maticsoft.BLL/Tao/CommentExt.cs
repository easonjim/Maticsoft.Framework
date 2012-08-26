using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class Comment
    {
        /// <summary>
        /// 对已选课程进行评论和评分
        /// </summary>
        public bool CourseComment(Model.Tao.Comment model)
        {
            return dal.CourseComment(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetCourseMoule(int iCourseID, int iPageIndex, int iPageSize)
        {
            return dal.GetCourseMoule(iCourseID, iPageIndex, iPageSize);
        }

        public int GetCommentCount(int iCourseID)
        {
            return dal.GetCommentCount(iCourseID);
        }

        public DataSet GetCommentsInfo(int CourseId, int startIndex, int pagesize, int ModuleID)
        {
            return dal.GetCommentsInfo(CourseId, startIndex, pagesize, ModuleID);
        }

        public int CommentCount(int courseId)
        {
            return dal.GetCommentCount(courseId);
        }

        public int GetAveScore(int cid)
        {
            return dal.GetAveScore(cid);
        }

        public List<Maticsoft.Model.Tao.Comment> GetCommentList(out int rowCount, out int pageCount, Model.Tao.PageModel model, int type)
        {
            DataSet ds = dal.GetComment(out rowCount, out pageCount, model, type);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        public List<Maticsoft.Model.Tao.Comment> GetChildComment(int parentId)
        {
            DataSet ds = dal.GetChildComment(parentId);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }
    }
}